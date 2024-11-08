using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Ticket;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Infrastructures.Exceptions;
using CinemaApp.Infrastructures.Queue.Email;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Mappers;
using CinemaApp.Models;
using CinemaApp.Utils.Enums;

namespace CinemaApp.Services
{
    public class TicketService(
        ITicketRepository ticketRepository, 
        IScheduleRepository scheduleRepository,
        IPaymentMethodRepository paymentMethodRepository,
        ITransactionRepository transactionRepository,
        IEmailService emailService,
        ApplicationDBContext applicationDBContext
    ) : ITicketService
    {
        private readonly ITicketRepository _ticketRepository = ticketRepository;

        private readonly IScheduleRepository _scheduleRepository = scheduleRepository;

        private readonly IPaymentMethodRepository _paymentMethodRepository = paymentMethodRepository;

        private readonly ITransactionRepository _transactionRepository = transactionRepository;

        private readonly IEmailService _emailService = emailService;

        private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;

        public async Task<AsyncVoidMethodBuilder> BuyTicketAsync(TicketBuyRequestDto ticketBuyRequestDto, int userId)
        {
            var scheduleIsExist = await _scheduleRepository.IsExistAsync(ticketBuyRequestDto.ScheduleId);

            if (!scheduleIsExist)
            {
                throw new DataNotFoundException("Schedule not found");
            }

            var paymentMethodIsExist = await _paymentMethodRepository.IsExistAsync(ticketBuyRequestDto.PaymentMethodId);

            if (!paymentMethodIsExist)
            {
                throw new DataNotFoundException("Payment method not found");
            }


            var dbTransaction = _applicationDBContext.Database.BeginTransaction();

            try
            {    
                var ticket = await _ticketRepository.CreateAsync(ticketBuyRequestDto.ToModel(userId, TicketStatus.Pending));

                await _transactionRepository.CreateAsync(new Transaction{
                    TicketId = ticket.Id,
                    PaymentMethodId = ticketBuyRequestDto.PaymentMethodId,
                    Status = TransactionStatus.Pending
                });

                dbTransaction.Commit();

                // Send email to user 
                // TODO: get user email from token
                await _emailService.SendEmailAsync(new EmailMessage{
                    To = "akhmadkhasan@gmail.com",
                    Subject = "Ticket Ordered",
                    Body = "Your ticket has been ordered"
                });

                return AsyncVoidMethodBuilder.Create();
            }
            catch (Exception)
            {
                dbTransaction.Rollback();

                throw;
            }
        }
    }
}
