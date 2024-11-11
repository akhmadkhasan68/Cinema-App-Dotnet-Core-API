using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Genre;
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
    public class GenreRepository(ApplicationDBContext applicationDBContext) : IGenreRepository
    {
        private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;

        public async Task<List<GenreDto>> GetAll(PaginationRequestDto paginationRequestDto)
        {
            var datas = _applicationDBContext.Genres.AsQueryable();

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

        public Task<GenreDto> FindOne(int id)
        {
            var data = _applicationDBContext.Genres.Find(id) ?? throw new DataNotFoundException("Genre not found");

            return Task.FromResult(data.ToDto());
        }

        public Task<bool> IsExist(int id)
        {
            return Task.FromResult(_applicationDBContext.Genres.Any(data => data.Id == id));
        }

        public async Task<AsyncVoidMethodBuilder> CreateAsync(Genre data)
        {
            await _applicationDBContext.Genres.AddAsync(data);
            await _applicationDBContext.SaveChangesAsync();

            return  AsyncVoidMethodBuilder.Create();
        }

        public async Task<AsyncVoidMethodBuilder> UpdateAsync(int id, Genre data)
        {
            var currentData = await _applicationDBContext.Genres.FindAsync(id) ?? throw new DataNotFoundException("Genre not found");

            currentData.Name = data.Name;
            currentData.IsActive = data.IsActive;

            await _applicationDBContext.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }

        public Task<bool> Delete(int id)
        {
            var currentData = _applicationDBContext.Genres.Find(id) ?? throw new DataNotFoundException("Genre not found");

            _applicationDBContext.Genres.Remove(currentData);
            _applicationDBContext.SaveChanges();

            return Task.FromResult(true);
        }

    }
}
