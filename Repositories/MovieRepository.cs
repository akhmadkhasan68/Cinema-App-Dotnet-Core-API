using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Genre;
using CinemaApp.Dtos.Movie;
using CinemaApp.Dtos.Pagination;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Infrastructures.Exceptions;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Models;
using CinemaApp.Utils.Constans;
using CinemaApp.Utils.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repositories
{
    public class MovieRepository(ApplicationDBContext applicationDBContext) : IMovieRepository
    {
        private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;

        public async Task<List<MovieDto>> GetAll(PaginationRequestDto paginationRequestDto)
        {
            var datas = _applicationDBContext.Movies.Include(movie => movie.Genre).AsSplitQuery().AsQueryable();

            if (!string.IsNullOrEmpty(paginationRequestDto.Keyword))
            {
                datas = datas.Where(data => data.Title.Contains(paginationRequestDto.Keyword));
            }

            if (!string.IsNullOrEmpty(paginationRequestDto.SortBy) && !string.IsNullOrEmpty(paginationRequestDto.Order))
            {
                switch (paginationRequestDto.SortBy)
                {
                    case "title":
                        datas = paginationRequestDto.Order.Equals(PaginationOrder.Asc) ? datas.OrderBy(data => data.Title) : datas.OrderByDescending(data => data.Title);
                        break;
                    case "duration_in_minutes":
                        datas = paginationRequestDto.Order.Equals(PaginationOrder.Asc) ? datas.OrderBy(data => data.DurationInMinutes) : datas.OrderByDescending(data => data.DurationInMinutes);
                        break;
                }
            }

            
            datas = datas.Skip(
                PaginationHelper.CalculateSkip(paginationRequestDto.Page, paginationRequestDto.PerPage)
            ).Take(paginationRequestDto.PerPage);

            return await datas.Select(movie => new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                DurationInMinutes = movie.DurationInMinutes,
                Description = movie.Description,
                Genre = new GenreDto
                {
                    Id = movie.Genre.Id,
                    Name = movie.Genre.Name,
                    IsActive = movie.Genre.IsActive,
                    CreatedAt = movie.Genre.CreatedAt,
                    UpdatedAt = movie.Genre.UpdatedAt
                },
                CreatedAt = movie.CreatedAt,
                UpdatedAt = movie.UpdatedAt
            }).ToListAsync();
        }

        public Task<MovieDto> FindOne(int id)
        {
            var movie = _applicationDBContext.Movies
                        .Include(movie => movie.Genre)
                        .AsSplitQuery()
                        .FirstOrDefault(movie => movie.Id == id) ?? throw new DataNotFoundException("Movie not found");

            return Task.FromResult(new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                DurationInMinutes = movie.DurationInMinutes,
                Description = movie.Description,
                Genre = new GenreDto
                {
                    Id = movie.Genre.Id,
                    Name = movie.Genre.Name,
                    IsActive = movie.Genre.IsActive,
                    CreatedAt = movie.Genre.CreatedAt,
                    UpdatedAt = movie.Genre.UpdatedAt
                },
                CreatedAt = movie.CreatedAt,
                UpdatedAt = movie.UpdatedAt
            });
        }

        public Task<bool> IsExist(int id)
        {
            return Task.FromResult(_applicationDBContext.Movies.Any(movie => movie.Id == id));
        }

        public async Task<AsyncVoidMethodBuilder> CreateAsync(Movie data)
        {
            await _applicationDBContext.Movies.AddAsync(data);
            await _applicationDBContext.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }

        public async Task<AsyncVoidMethodBuilder> UpdateAsync(int id, Movie data)
        {
            var existingData = await _applicationDBContext.Movies
                                .Include(movie => movie.Genre)
                                .AsSplitQuery()
                                .FirstOrDefaultAsync(movie => movie.Id == id) ?? throw new DataNotFoundException("Movie not found");

            existingData.Title = data.Title;
            existingData.DurationInMinutes = data.DurationInMinutes;
            existingData.Description = data.Description;
            existingData.Genre = data.Genre;

            await _applicationDBContext.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }

        public Task<bool> Delete(int id)
        {
            var movie = _applicationDBContext.Movies.Find(id) ?? throw new DataNotFoundException("Movie not found");

            _applicationDBContext.Movies.Remove(movie);
            _applicationDBContext.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
