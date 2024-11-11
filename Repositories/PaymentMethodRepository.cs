using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Pagination;
using CinemaApp.Dtos.PaymentMethod;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Infrastructures.Exceptions;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Mappers;
using CinemaApp.Models;
using CinemaApp.Utils.Constans;
using CinemaApp.Utils.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repositories
{
    public class PaymentMethodRepository(ApplicationDBContext applicationDBContext) : IPaymentMethodRepository
    {
        private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;

        public async Task<List<PaymentMethodDto>> GetAll(PaginationRequestDto paginationRequestDto)
        {
            var datas = _applicationDBContext.PaymentMethods.AsQueryable();

            if (!string.IsNullOrEmpty(paginationRequestDto.Keyword))
            {
                datas = datas.Where(data => data.Name.Contains(paginationRequestDto.Keyword));
            }

            if (!string.IsNullOrEmpty(paginationRequestDto.SortBy) && !string.IsNullOrEmpty(paginationRequestDto.Order))
            {
                switch (paginationRequestDto.SortBy)
                {
                    case "name":
                        datas = paginationRequestDto.Order.Equals(PaginationOrder.Asc) ? datas.OrderBy(data => data.Name) : datas.OrderByDescending(data => data.Name);
                        break;
                    case "is_active":
                        datas = paginationRequestDto.Order.Equals(PaginationOrder.Asc) ? datas.OrderBy(data => data.IsActive) : datas.OrderByDescending(data => data.IsActive);
                        break;
                }
            }

            
            datas = datas.Skip(
                PaginationHelper.CalculateSkip(paginationRequestDto.Page, paginationRequestDto.PerPage)
            ).Take(paginationRequestDto.PerPage);

            return await datas.Select(data => data.ToDto()).ToListAsync();
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
