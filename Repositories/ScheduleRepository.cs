using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Genre;
using CinemaApp.Dtos.Movie;
using CinemaApp.Dtos.Schedule;
using CinemaApp.Dtos.Studio;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repositories
{
    public class ScheduleRepository(ApplicationDBContext applicationDBContext) : IScheduleRepository
    {

        private readonly ApplicationDBContext _context = applicationDBContext;

        public Task<List<ScheduleDto>> GetAll()
        {
            var datas = _context.Schedules
                        .Include(data => data.Movie)
                        .ThenInclude(data => data.Genre)
                        .Include(data => data.Studio)
                        .AsSplitQuery()
                        .ToList();

            return Task.FromResult(datas.Select(data => new ScheduleDto{
                Id = data.Id,
                Movie = new MovieDto
                {
                    Id = data.Movie.Id,
                    Title = data.Movie.Title,
                    DurationInMinutes = data.Movie.DurationInMinutes,
                    Description = data.Movie.Description,
                    Genre = new GenreDto
                    {
                        Id = data.Movie.Genre.Id,
                        Name = data.Movie.Genre.Name,
                        IsActive = data.Movie.Genre.IsActive,
                        CreatedAt = data.Movie.Genre.CreatedAt,
                        UpdatedAt = data.Movie.Genre.UpdatedAt
                    },
                    CreatedAt = data.Movie.CreatedAt,
                    UpdatedAt = data.Movie.UpdatedAt
                },
                Studio = new StudioDto
                {
                    Id = data.Studio.Id,
                    Name = data.Studio.Name,
                    Capacity = data.Studio.Capacity,
                    CreatedAt = data.Studio.CreatedAt,
                    UpdatedAt = data.Studio.UpdatedAt
                },
                DateTime = data.DateTime,
                Price = data.Price,
                CreatedAt = data.CreatedAt,
                UpdatedAt = data.UpdatedAt
            }).ToList());
        }

        public Task<ScheduleDto> FindOne(int id)
        {
            var data = _context.Schedules
                        .Include(data => data.Movie)
                        .ThenInclude(data => data.Genre)
                        .Include(data => data.Studio)
                        .AsSplitQuery()
                        .FirstOrDefault(data => data.Id == id) ?? throw new Exception("Data not found");

            return Task.FromResult(new ScheduleDto
            {
                Id = data.Id,
                Movie = new MovieDto
                {
                    Id = data.Movie.Id,
                    Title = data.Movie.Title,
                    DurationInMinutes = data.Movie.DurationInMinutes,
                    Description = data.Movie.Description,
                    Genre = new GenreDto
                    {
                        Id = data.Movie.Genre.Id,
                        Name = data.Movie.Genre.Name,
                        IsActive = data.Movie.Genre.IsActive,
                        CreatedAt = data.Movie.Genre.CreatedAt,
                        UpdatedAt = data.Movie.Genre.UpdatedAt
                    },
                    CreatedAt = data.Movie.CreatedAt,
                    UpdatedAt = data.Movie.UpdatedAt
                },
                Studio = new StudioDto
                {
                    Id = data.Studio.Id,
                    Name = data.Studio.Name,
                    Capacity = data.Studio.Capacity,
                    CreatedAt = data.Studio.CreatedAt,
                    UpdatedAt = data.Studio.UpdatedAt
                },
                DateTime = data.DateTime,
                Price = data.Price,
                CreatedAt = data.CreatedAt,
                UpdatedAt = data.UpdatedAt
            });
        }

        public async Task<AsyncVoidMethodBuilder> CreateAsync(Schedule data)
        {
            await _context.Schedules.AddAsync(data);
            await _context.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }

        public async Task<AsyncVoidMethodBuilder> UpdateAsync(int id, Schedule data)
        {
            var existingData = await _context.Schedules
                                .Include(data => data.Movie)
                                .ThenInclude(data => data.Genre)
                                .Include(data => data.Studio)
                                .AsSplitQuery()
                                .FirstOrDefaultAsync(data => data.Id == id) ?? throw new Exception("Data not found");

            existingData.MovieId = data.MovieId;
            existingData.StudioId = data.StudioId;
            existingData.DateTime = data.DateTime;
            existingData.Price = data.Price;

            await _context.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }

        public Task<bool> Delete(int id)
        {
            var existingData = _context.Schedules
                                .FirstOrDefault(data => data.Id == id) ?? throw new Exception("Data not found");

            _context.Schedules.Remove(existingData);
            _context.SaveChanges();

            return Task.FromResult(true);
        }

        public async Task<bool> IsExistAsync(int scheduleId)
        {
            var data = await _context.Schedules.AnyAsync(schedule => schedule.Id == scheduleId);

            return data;
        }
    }
}
