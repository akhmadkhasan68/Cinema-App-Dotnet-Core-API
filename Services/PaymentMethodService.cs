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

        public Task<PaymentMethodDto> Create(PaymentMethod data)
        {
            return _paymentMethodRepository.Create(data);
        }

        public Task<PaymentMethodDto> Update(int id, PaymentMethod data)
        {
            return _paymentMethodRepository.Update(id, data);
        }

        public Task<bool> Delete(int id)
        {
            return _paymentMethodRepository.Delete(id);
        }
    }
}
