using CinemaApp.Dtos.PaymentMethod;
using CinemaApp.Models;

namespace CinemaApp.Mappers
{
    public static class PaymentMethodMapper
    {
        public static PaymentMethodDto ToDto(this PaymentMethod paymentMethod)
        {
            return new PaymentMethodDto
            {
                Id = paymentMethod.Id,
                Name = paymentMethod.Name,
                IsActive = paymentMethod.IsActive,
                CreatedAt = paymentMethod.CreatedAt,
                UpdatedAt = paymentMethod.UpdatedAt,
            };
        }   

        public static PaymentMethodResponseDto ToResponse(this PaymentMethodDto PaymentMethodDto)
        {
            return new PaymentMethodResponseDto
            {
                Id = PaymentMethodDto.Id,
                Name = PaymentMethodDto.Name,
                IsActive = PaymentMethodDto.IsActive,
                CreatedAt = PaymentMethodDto.CreatedAt,
                UpdatedAt = PaymentMethodDto.UpdatedAt,
            };
        }     

        public static PaymentMethod ToModel(this PaymentMethodRequestDto paymentMethodRequest)
        {
            return new PaymentMethod
            {
                Name = paymentMethodRequest.Name,
                IsActive = paymentMethodRequest.IsActive,
            };
        }
    }
}
