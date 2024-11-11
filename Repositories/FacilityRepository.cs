using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Facility;
using CinemaApp.Dtos.Pagination;
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
    public class FacilityRepository(ApplicationDBContext context) : IFacilityRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<List<FacilityDto>> GetAll(PaginationRequestDto paginationRequestDto)
        {
            var datas = _context.Facilities.AsQueryable();

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

        public Task<FacilityDto> FindOne(int id)
        {
            var data = _context.Facilities.Find(id) ?? throw new DataNotFoundException("Facility not found");
            return Task.FromResult(data.ToDto());
        }

        public async Task<AsyncVoidMethodBuilder> CreateAsync(Facility data)
        {
            await _context.Facilities.AddAsync(data);
            await _context.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }

        public async Task<AsyncVoidMethodBuilder> UpdateAsync(int id, Facility data)
        {
            var existingStudio = await _context.Facilities.FindAsync(id) ?? throw new DataNotFoundException("Facility not found");

            existingStudio.Name = data.Name;
            existingStudio.IsActive = data.IsActive;

            await _context.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }

        public Task<bool> Delete(int id)
        {
            var facility = _context.Facilities.Find(id) ?? throw new DataNotFoundException("Facility not found");

            _context.Facilities.Remove(facility);
            _context.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
