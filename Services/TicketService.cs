using CinemaApp.Dtos.Ticket;
using CinemaApp.Infrastructures.Queue.Email;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Mappers;
using CinemaApp.Utils.Enums;

namespace CinemaApp.Services
{
    public class TicketService(
        ITicketRepository ticketRepository, 
        IScheduleRepository scheduleRepository,
        IEmailService emailService
    ) : ITicketService
    {
        private readonly ITicketRepository _ticketRepository = ticketRepository;

        private readonly IScheduleRepository _scheduleRepository = scheduleRepository;

        private readonly IEmailService _emailService = emailService;

        public async Task<TicketDto> BuyTicketAsync(TicketBuyRequestDto ticketBuyRequestDto, int userId)
        {
            var scheduleIsExist = await _scheduleRepository.IsExistAsync(ticketBuyRequestDto.ScheduleId);

            if (!scheduleIsExist)
            {
                throw new Exception("Schedule not found");
            }

            var createdTicket = await _ticketRepository.CreateAsync(ticketBuyRequestDto.ToModel(userId, TicketStatus.Pending));

            // Send email to user 
            // TODO: get user email from token
            await _emailService.SendEmailAsync(new EmailMessage{
                To = "akhmadkhasan@gmail.com",
                Subject = "Ticket Ordered",
                Body = "Your ticket has been ordered"
            });

            return createdTicket;
        }
    }
}
