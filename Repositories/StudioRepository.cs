using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Pagination;
using CinemaApp.Dtos.Studio;
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
    public class StudioRepository(ApplicationDBContext context) : IStudioRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<List<StudioDto>> GetAll(PaginationRequestDto paginationRequestDto)
        {
            var datas = _context.Studios.AsQueryable();

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
                    case "capacity":
                        datas = paginationRequestDto.Order.Equals(PaginationOrder.Asc) ? datas.OrderBy(data => data.Capacity) : datas.OrderByDescending(data => data.Capacity);
                        break;
                }
            }

            
            datas = datas.Skip(
                PaginationHelper.CalculateSkip(paginationRequestDto.Page, paginationRequestDto.PerPage)
            ).Take(paginationRequestDto.PerPage);

            return await datas.Select(studio => studio.ToDto()).ToListAsync();
        }

        public Task<StudioDto> FindOne(int id)
        {
            var studio = _context.Studios.Find(id) ?? throw new DataNotFoundException("Studio not found");
            return Task.FromResult(studio.ToDto());
        }

        public Task<bool> IsExist(int id)
        {
            return Task.FromResult(_context.Studios.Any(studio => studio.Id == id));
        }

        public async Task<AsyncVoidMethodBuilder> CreateAsync(Studio data)
        {
            await _context.Studios.AddAsync(data);
            await _context.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }

        public async Task<AsyncVoidMethodBuilder> UpdateAsync(int id, Studio data)
        {
            var existingStudio = await _context.Studios.FindAsync(id) ?? throw new DataNotFoundException("Studio not found");

            existingStudio.Name = data.Name;
            existingStudio.Capacity = data.Capacity;

            await _context.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }

        public Task<bool> Delete(int id)
        {
            var studio = _context.Studios.Find(id) ?? throw new DataNotFoundException("Studio not found");

            _context.Studios.Remove(studio);
            _context.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
