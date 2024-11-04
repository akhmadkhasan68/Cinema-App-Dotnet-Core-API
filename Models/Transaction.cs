using CinemaApp.Utils.Enums;

namespace CinemaApp.Models;

public class Transaction : BaseModel
{
    public int Id { get; set; }

    public int TicketId { get; set; }

    public int PaymentMethodId { get; set; }

    public TransactionStatus Status { get; set; }

    public Ticket Ticket { get; set; } = null!;

    public PaymentMethod PaymentMethod { get; set; } = null!;
}
