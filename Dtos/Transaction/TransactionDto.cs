using CinemaApp.Dtos.PaymentMethod;
using CinemaApp.Dtos.Ticket;
using CinemaApp.Utils.Enums;

namespace CinemaApp.Dtos.Transaction
{
    public class TransactionDto
    {
        public int Id { get; set; }

        public int TicketId { get; set; }

        public int PaymentMethodId { get; set; }

        public TransactionStatus Status { get; set; }

        public TicketDto? Ticket { get; set; } = null!;

        public PaymentMethodDto? PaymentMethod { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
