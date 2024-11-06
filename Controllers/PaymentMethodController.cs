using CinemaApp.Dtos.PaymentMethod;
using CinemaApp.Infrastructures.Responses;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Responses;
using CinemaApp.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    [ApiController]
    [Route("api/payment-methods")]
    public class PaymentMethodController(IPaymentMethodRepository paymentMethodRepository) : ControllerBase
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository = paymentMethodRepository;

        [HttpGet]
        public async Task<ActionResult<IApiResponse<List<PaymentMethodResponseDto>>>> GetAll()
        {
            var datas = await _paymentMethodRepository.GetAll();

            return Ok(ApiResponse<List<PaymentMethodResponseDto>>.Success(datas.Select(data => data.ToResponse()).ToList()));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IApiResponse<PaymentMethodResponseDto>>> FindOne([FromRoute] int id)
        {
            var data = await _paymentMethodRepository.FindOne(id);

            return Ok(ApiResponse<PaymentMethodResponseDto>.Success(data.ToResponse()));
        }

        [HttpPost]
        public async Task<ActionResult<IApiResponse<PaymentMethodResponseDto>>> Create([FromBody] PaymentMethodRequestDto paymentMethodRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _paymentMethodRepository.Create(paymentMethodRequestDto.ToModel());

            return Ok(ApiResponse<PaymentMethodResponseDto>.Success(data.ToResponse()));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<IApiResponse<PaymentMethodResponseDto>>> Update([FromRoute] int id, [FromBody] PaymentMethodRequestDto paymentMethodRequestDto)
        {
            var data = await _paymentMethodRepository.Update(id, paymentMethodRequestDto.ToModel());

            return Ok(ApiResponse<PaymentMethodResponseDto>.Success(data.ToResponse()));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<IApiResponse<bool>>> Delete([FromRoute] int id)
        {
            var isDeleted = await _paymentMethodRepository.Delete(id);

            return Ok(ApiResponse<bool>.Success(isDeleted));
        }
    }
}
