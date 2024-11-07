using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApp.Dtos.Schedule;
using CinemaApp.Dtos.User;
using CinemaApp.Utils.Enums;

namespace CinemaApp.Dtos.Ticket
{
    public class TicketDto
    {
        public int Id { get; set; }

        public int ScheduleId { get; set; }

        public int UserId { get; set; }

        public int SeatNumber { get; set; }

        public TicketStatus Status { get; set; }

        public ScheduleDto? Schedule { get; set; }

        public UserDto? User { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
