using CinemaApp.Dtos.PaymentMethod;
using CinemaApp.Models;

namespace CinemaApp.Interfaces.Repositories
{
    public interface IPaymentMethodRepository : IBaseRepository<PaymentMethodDto, PaymentMethod> {
        public Task<bool> IsExistAsync(int id);
    }
}
