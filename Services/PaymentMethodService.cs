using System.Runtime.CompilerServices;
using CinemaApp.Dtos.PaymentMethod;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Models;

namespace CinemaApp.Services
{
    public class PaymentMethodService(IPaymentMethodRepository paymentMethodRepository) : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository = paymentMethodRepository;

        public Task<List<PaymentMethodDto>> GetAll()
        {
            return _paymentMethodRepository.GetAll();
        }

        public Task<PaymentMethodDto> FindOne(int id)
        {
            return _paymentMethodRepository.FindOne(id);
        }

        public async Task<AsyncVoidMethodBuilder> CreateAsync(PaymentMethod data)
        {
            return await _paymentMethodRepository.CreateAsync(data);
        }

        public async Task<AsyncVoidMethodBuilder> UpdateAsync(int id, PaymentMethod data)
        {
            return  await _paymentMethodRepository.UpdateAsync(id, data);
        }

        public Task<bool> Delete(int id)
        {
            return _paymentMethodRepository.Delete(id);
        }
    }
}
