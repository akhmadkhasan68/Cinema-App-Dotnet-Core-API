using CinemaApp.Utils.Enums;

namespace CinemaApp.Models;

public class Ticket : BaseModel
{
    public int ScheduleId { get; set; }

    public int UserId { get; set; }

    public int SeatNumber { get; set; }

    public TicketStatus Status { get; set; }

    public Schedule Schedule { get; set; } = null!;

    public User User { get; set; } = null!;
}
