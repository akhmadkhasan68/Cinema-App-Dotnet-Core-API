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

        public Task<MovieDto> Create(Movie data)
        {
            _applicationDBContext.Movies.Add(data);
            _applicationDBContext.SaveChanges();

            var insertedData = _applicationDBContext.Movies
                                .Include(movie => movie.Genre)
                                .AsSplitQuery()
                                .FirstOrDefault(movie => movie.Id == data.Id) ?? throw new Exception("Movie not found");

            return Task.FromResult(new MovieDto
            {
                Id = insertedData.Id,
                Title = insertedData.Title,
                DurationInMinutes = insertedData.DurationInMinutes,
                Description = insertedData.Description,
                Genre = new GenreDto
                {
                    Id = insertedData.Genre.Id,
                    Name = insertedData.Genre.Name,
                    IsActive = insertedData.Genre.IsActive,
                    CreatedAt = insertedData.Genre.CreatedAt,
                    UpdatedAt = insertedData.Genre.UpdatedAt
                },
                CreatedAt = insertedData.CreatedAt,
                UpdatedAt = insertedData.UpdatedAt
            });
        }

        public Task<MovieDto> Update(int id, Movie data)
        {
            var existingData = _applicationDBContext.Movies
                                .Include(movie => movie.Genre)
                                .AsSplitQuery()
                                .FirstOrDefault(movie => movie.Id == id) ?? throw new Exception("Movie not found");

            existingData.Title = data.Title;
            existingData.DurationInMinutes = data.DurationInMinutes;
            existingData.Description = data.Description;
            existingData.Genre = data.Genre;

            _applicationDBContext.SaveChanges();

            return Task.FromResult(new MovieDto
            {
                Id = existingData.Id,
                Title = existingData.Title,
                DurationInMinutes = existingData.DurationInMinutes,
                Description = existingData.Description,
                Genre = new GenreDto
                {
                    Id = existingData.Genre.Id,
                    Name = existingData.Genre.Name,
                    IsActive = existingData.Genre.IsActive,
                    CreatedAt = existingData.Genre.CreatedAt,
                    UpdatedAt = existingData.Genre.UpdatedAt
                },
                CreatedAt = existingData.CreatedAt,
                UpdatedAt = existingData.UpdatedAt
            });
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
