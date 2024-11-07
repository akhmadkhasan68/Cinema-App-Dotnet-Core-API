using CinemaApp.Dtos.Ticket;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Mappers;
using CinemaApp.Utils.Enums;

namespace CinemaApp.Services
{
    public class TicketService(ITicketRepository ticketRepository, IScheduleRepository scheduleRepository) : ITicketService
    {
        private readonly ITicketRepository _ticketRepository = ticketRepository;

        private readonly IScheduleRepository _scheduleRepository = scheduleRepository;

        public async Task<TicketDto> BuyTicketAsync(TicketBuyRequestDto ticketBuyRequestDto, int userId)
        {
            var scheduleIsExist = await _scheduleRepository.IsExistAsync(ticketBuyRequestDto.ScheduleId);

            if (!scheduleIsExist)
            {
                throw new Exception("Schedule not found");
            }

            var createdTicket = await _ticketRepository.CreateAsync(ticketBuyRequestDto.ToModel(userId, TicketStatus.Pending));

            return createdTicket;
        }
    }
}
