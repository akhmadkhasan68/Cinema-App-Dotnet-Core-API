using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApp.Dtos.Ticket;
using CinemaApp.Models;

namespace CinemaApp.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        public Task<TicketDto> CreateAsync(Ticket ticket);
    }
}
