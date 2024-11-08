using CinemaApp.Dtos.Ticket;
using CinemaApp.Models;

namespace CinemaApp.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        public Task<TicketDto> CreateAsync(Ticket ticket);
    }
}
