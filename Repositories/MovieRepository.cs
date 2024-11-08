using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Genre;
using CinemaApp.Dtos.Movie;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repositories
{
    public class MovieRepository(ApplicationDBContext applicationDBContext) : IMovieRepository
    {
        private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;

        public Task<List<MovieDto>> GetAll()
        {
            var movies = _applicationDBContext.Movies
                        .Include(movie => movie.Genre)
                        .AsSplitQuery()
                        .ToList();
            
            return Task.FromResult(movies.Select(movie => new MovieDto
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
            }).ToList());
        }

        public Task<MovieDto> FindOne(int id)
        {
            var movie = _applicationDBContext.Movies
                        .Include(movie => movie.Genre)
                        .AsSplitQuery()
                        .FirstOrDefault(movie => movie.Id == id) ?? throw new Exception("Movie not found");

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
                                .FirstOrDefaultAsync(movie => movie.Id == id) ?? throw new Exception("Movie not found");

            existingData.Title = data.Title;
            existingData.DurationInMinutes = data.DurationInMinutes;
            existingData.Description = data.Description;
            existingData.Genre = data.Genre;

            await _applicationDBContext.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }

        public Task<bool> Delete(int id)
        {
            var movie = _applicationDBContext.Movies.Find(id) ?? throw new Exception("Movie not found");

            _applicationDBContext.Movies.Remove(movie);
            _applicationDBContext.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
