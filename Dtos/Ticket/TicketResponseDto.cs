using CinemaApp.Dtos.Schedule;
using CinemaApp.Dtos.User;

namespace CinemaApp.Dtos.Ticket
{
    public class TicketResponseDto
    {
        public int Id { get; set; }

        public ScheduleResponseDto? Schedule { get; set; }

        public UserResponseDto? User { get; set; }

        public int SeatNumber { get; set; }

        public string Status { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
