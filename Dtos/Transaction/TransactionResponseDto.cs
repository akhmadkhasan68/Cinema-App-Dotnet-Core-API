using CinemaApp.Dtos.PaymentMethod;
using CinemaApp.Dtos.Ticket;
using CinemaApp.Utils.Enums;

namespace CinemaApp.Dtos.Transaction
{
    public class TransactionResponseDto
    {
        public int Id { get; set; }

        public TransactionStatus Status { get; set; }

        public TicketResponseDto? Ticket { get; set; }

        public PaymentMethodResponseDto? PaymentMethod { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
