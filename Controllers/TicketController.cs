using CinemaApp.Dtos.Ticket;
using CinemaApp.Infrastructures.Responses;
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
        public async Task<ActionResult<ApiResponse>> BuyTicketAsync([FromBody] TicketBuyRequestDto ticketBuyRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userID = 2; // TODO: get userId from token
            await _ticketService.BuyTicketAsync(ticketBuyRequestDto, userID); 

            return Ok(ApiResponse.Success("Ticket bought successfully"));
        }
    }
}
