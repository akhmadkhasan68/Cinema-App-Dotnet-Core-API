using CinemaApp.Dtos.Ticket;
using CinemaApp.Models;
using CinemaApp.Utils.Enums;

namespace CinemaApp.Mappers
{
    public static class TicketMapper
    {
        public static TicketDto ToDto(this Ticket ticket)
        {
            return new TicketDto
            {
                Id = ticket.Id,
                ScheduleId = ticket.ScheduleId,
                UserId = ticket.UserId,
                SeatNumber = ticket.SeatNumber,
                Status = ticket.Status,
                Schedule = ticket.Schedule?.ToDto() ?? null,
                User = ticket.User?.ToDto() ?? null,
                CreatedAt = ticket.CreatedAt,
                UpdatedAt = ticket.UpdatedAt,
            };
        }   

        public static TicketResponseDto ToResponse(this TicketDto ticketDto)
        {
            return new TicketResponseDto
            {
                Id = ticketDto.Id,
                Schedule = ticketDto.Schedule?.ToResponse() ?? null,
                User = ticketDto.User?.ToResponse() ?? null,
                SeatNumber = ticketDto.SeatNumber,
                Status = ticketDto.Status.ToString(),
                CreatedAt = ticketDto.CreatedAt,
                UpdatedAt = ticketDto.UpdatedAt,
            };
        }     

        public static Ticket ToModel(this TicketBuyRequestDto ticketBuyRequestDto, int UserId, TicketStatus status)
        {
            return new Ticket
            {
                ScheduleId = ticketBuyRequestDto.ScheduleId,
                UserId = UserId,
                SeatNumber = ticketBuyRequestDto.SeatNumber,
                Status = status,
            };
        }
    }
}
