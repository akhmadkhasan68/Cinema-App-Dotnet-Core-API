using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Dtos.Ticket
{
    public class TicketBuyRequestDto
    {
        [Required(ErrorMessage = "Schedule is required")]
        public int ScheduleId { get; set; }

        [Required(ErrorMessage = "Seat number is required")]
        public int SeatNumber { get; set; }

        [Required(ErrorMessage = "Payment method is required")]
        public int PaymentMethodId { get; set; }
    }
}
