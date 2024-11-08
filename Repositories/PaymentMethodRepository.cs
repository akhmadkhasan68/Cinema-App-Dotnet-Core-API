using System.Runtime.CompilerServices;
using CinemaApp.Dtos.PaymentMethod;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Infrastructures.Exceptions;
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
            var data = _applicationDBContext.PaymentMethods.Find(id) ?? throw new DataNotFoundException("Data not found");
            return Task.FromResult(data.ToDto());
        }

        public async Task<bool> IsExistAsync(int id)
        {
            var data = await _applicationDBContext.PaymentMethods.FindAsync(id);

            return data != null;
        }

        public async Task<AsyncVoidMethodBuilder> CreateAsync(PaymentMethod data)
        {
            await _applicationDBContext.PaymentMethods.AddAsync(data);
            await _applicationDBContext.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }

        public async Task<AsyncVoidMethodBuilder> UpdateAsync(int id, PaymentMethod data)
        {
            var existingData = await _applicationDBContext.PaymentMethods.FindAsync(id) ?? throw new DataNotFoundException("Data not found");

            existingData.Name = data.Name;
            existingData.IsActive = data.IsActive;

            await _applicationDBContext.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }

        public Task<bool> Delete(int id)
        {
            var data = _applicationDBContext.PaymentMethods.Find(id) ?? throw new DataNotFoundException("Data not found");

            _applicationDBContext.PaymentMethods.Remove(data);
            _applicationDBContext.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
