using CinemaApp.Dtos.Ticket;
using CinemaApp.Infrastructures.Responses;
using CinemaApp.Interfaces.Responses;
using CinemaApp.Interfaces.Services;
using CinemaApp.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<IApiResponse<TicketResponseDto>>> BuyTicketAsync([FromBody] TicketBuyRequestDto ticketBuyRequestDto)
        {
            var userID = 2; // TODO: get userId from token
            var ticket = await _ticketService.BuyTicketAsync(ticketBuyRequestDto, userID); 

            return Ok(ApiResponse<TicketResponseDto>.Success(ticket.ToResponse()));
        }
    }
}
