using CinemaApp.Dtos.PaymentMethod;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Mappers;
using CinemaApp.Models;

namespace CinemaApp.Repositories
{
    public class PaymentMethodRepository(ApplicationDBContext applicationDBContext) : IPaymentMethodRepository
    {
        private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;

        public Task<List<PaymentMethodDto>> GetAll()
        {
            var datas = _applicationDBContext.PaymentMethods.ToList().Select(data => data.ToDto()).ToList();

            return Task.FromResult(datas);
        }

        public Task<PaymentMethodDto> FindOne(int id)
        {
            var data = _applicationDBContext.PaymentMethods.Find(id) ?? throw new Exception("Data not found");
            return Task.FromResult(data.ToDto());
        }

        public Task<PaymentMethodDto> Create(PaymentMethod data)
        {
            _applicationDBContext.PaymentMethods.Add(data);
            _applicationDBContext.SaveChanges();

            return Task.FromResult(data.ToDto());
        }

        public Task<PaymentMethodDto> Update(int id, PaymentMethod data)
        {
            var existingData = _applicationDBContext.PaymentMethods.Find(id) ?? throw new Exception("Data not found");

            existingData.Name = data.Name;
            existingData.IsActive = data.IsActive;

            _applicationDBContext.SaveChanges();

            return Task.FromResult(existingData.ToDto());
        }

        public Task<bool> Delete(int id)
        {
            var data = _applicationDBContext.PaymentMethods.Find(id) ?? throw new Exception("Data not found");

            _applicationDBContext.PaymentMethods.Remove(data);
            _applicationDBContext.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
