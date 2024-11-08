using System.Runtime.CompilerServices;
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

        public async Task<AsyncVoidMethodBuilder> CreateAsync(Ticket ticket)
        {
            await _applicationDBContext.Tickets.AddAsync(ticket);
            await _applicationDBContext.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }
    }
}
