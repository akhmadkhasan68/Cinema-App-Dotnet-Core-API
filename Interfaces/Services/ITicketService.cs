using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApp.Dtos.Ticket;

namespace CinemaApp.Interfaces.Services
{
    public interface ITicketService
    {
        public Task<TicketDto> BuyTicketAsync(TicketBuyRequestDto ticketBuyRequestDto, int userId);
    }
}
