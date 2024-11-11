using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Ticket;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Mappers;
using CinemaApp.Models;

namespace CinemaApp.Repositories
{
    public class TicketRepository(ApplicationDBContext applicationDBContext) : ITicketRepository
    {
        private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;

        public async Task<TicketDto> CreateAsync(Ticket ticket)
        {
            var newTicket = await _applicationDBContext.Tickets.AddAsync(ticket);
            await _applicationDBContext.SaveChangesAsync();

            return newTicket.Entity.ToDto();
        }
    }
}
