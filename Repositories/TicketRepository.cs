using CinemaApp.Dtos.Ticket;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Mappers;
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repositories
{
    public class TicketRepository(ApplicationDBContext applicationDBContext) : ITicketRepository
    {
        private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;

        public async Task<TicketDto> CreateAsync(Ticket ticket)
        {
            await _applicationDBContext.Tickets.AddAsync(ticket);
            await _applicationDBContext.SaveChangesAsync();

            var createdData = await _applicationDBContext.Tickets
                            .Include(data => data.User)
                            .Include(data => data.Schedule)
                            .ThenInclude(data => data.Movie)
                            .ThenInclude(data => data.Genre)
                            .Include(data => data.Schedule)
                            .ThenInclude(data => data.Studio)
                            .FirstOrDefaultAsync(data => data.Id == ticket.Id) ?? throw new Exception("Data not found");

            return createdData.ToDto();
        }
    }
}
