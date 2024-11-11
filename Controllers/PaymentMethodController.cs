using CinemaApp.Dtos.Pagination;
using CinemaApp.Dtos.PaymentMethod;
using CinemaApp.Infrastructures.Responses;
using CinemaApp.Interfaces.Services;
using CinemaApp.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    [ApiController]
    [Route("api/payment-methods")]
    public class PaymentMethodController(IPaymentMethodService paymentMethodService) : ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService = paymentMethodService;

        [HttpGet]
        public async Task<ActionResult<PaginateResponse<PaymentMethodResponseDto>>> GetAll([FromQuery] PaginationRequestDto paginationRequestDto)
        {
            var datas = await _paymentMethodService.GetAll(paginationRequestDto);

            return Ok(PaginateResponse<PaymentMethodResponseDto>.Success(
                datas.Select(data => data.ToResponse()).ToList(),
                paginationRequestDto.Page,
                paginationRequestDto.PerPage,
                datas.Count
            ));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<PaymentMethodResponseDto>>> FindOne([FromRoute] int id)
        {
            var data = await _paymentMethodService.FindOne(id);

            return Ok(ApiResponse<PaymentMethodResponseDto>.Success(data.ToResponse()));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create([FromBody] PaymentMethodRequestDto paymentMethodRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _paymentMethodService.CreateAsync(paymentMethodRequestDto.ToModel());

            return Ok(ApiResponse.Success("Payment method created successfully"));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse>> Update([FromRoute] int id, [FromBody] PaymentMethodRequestDto paymentMethodRequestDto)
        {
            await _paymentMethodService.UpdateAsync(id, paymentMethodRequestDto.ToModel());

            return Ok(ApiResponse.Success("Payment method updated successfully"));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete([FromRoute] int id)
        {
            var isDeleted = await _paymentMethodService.Delete(id);

            return Ok(ApiResponse<bool>.Success(isDeleted));
        }
    }
}
