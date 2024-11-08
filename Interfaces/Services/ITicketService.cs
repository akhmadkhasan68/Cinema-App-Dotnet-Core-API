using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Ticket;

namespace CinemaApp.Interfaces.Services
{
    public interface ITicketService
    {
        public Task<AsyncVoidMethodBuilder> BuyTicketAsync(TicketBuyRequestDto ticketBuyRequestDto, int userId);
    }
}
