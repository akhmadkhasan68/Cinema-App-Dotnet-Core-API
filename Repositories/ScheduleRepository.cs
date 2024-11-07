using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Task<ScheduleDto> Create(Schedule data)
        {
            _context.Schedules.Add(data);
            _context.SaveChanges();

            var insertedData = _context.Schedules
                                .Include(data => data.Movie)
                                .ThenInclude(data => data.Genre)
                                .Include(data => data.Studio)
                                .AsSplitQuery()
                                .FirstOrDefault(data => data.Id == data.Id) ?? throw new Exception("Data not found");

            return Task.FromResult(new ScheduleDto
            {
                Id = insertedData.Id,
                Movie = new MovieDto
                {
                    Id = insertedData.Movie.Id,
                    Title = insertedData.Movie.Title,
                    DurationInMinutes = insertedData.Movie.DurationInMinutes,
                    Description = insertedData.Movie.Description,
                    Genre = new GenreDto
                    {
                        Id = insertedData.Movie.Genre.Id,
                        Name = insertedData.Movie.Genre.Name,
                        IsActive = insertedData.Movie.Genre.IsActive,
                        CreatedAt = insertedData.Movie.Genre.CreatedAt,
                        UpdatedAt = insertedData.Movie.Genre.UpdatedAt
                    },
                    CreatedAt = insertedData.Movie.CreatedAt,
                    UpdatedAt = insertedData.Movie.UpdatedAt
                },
                Studio = new StudioDto
                {
                    Id = insertedData.Studio.Id,
                    Name = insertedData.Studio.Name,
                    Capacity = insertedData.Studio.Capacity,
                    CreatedAt = insertedData.Studio.CreatedAt,
                    UpdatedAt = insertedData.Studio.UpdatedAt
                },
                DateTime = insertedData.DateTime,
                Price = insertedData.Price,
                CreatedAt = insertedData.CreatedAt,
                UpdatedAt = insertedData.UpdatedAt
            });
        }

        public Task<ScheduleDto> Update(int id, Schedule data)
        {
            var existingData = _context.Schedules
                                .Include(data => data.Movie)
                                .ThenInclude(data => data.Genre)
                                .Include(data => data.Studio)
                                .AsSplitQuery()
                                .FirstOrDefault(data => data.Id == id) ?? throw new Exception("Data not found");

            existingData.MovieId = data.MovieId;
            existingData.StudioId = data.StudioId;
            existingData.DateTime = data.DateTime;
            existingData.Price = data.Price;

            _context.SaveChanges();

            return Task.FromResult(new ScheduleDto
            {
                Id = existingData.Id,
                Movie = new MovieDto
                {
                    Id = existingData.Movie.Id,
                    Title = existingData.Movie.Title,
                    DurationInMinutes = existingData.Movie.DurationInMinutes,
                    Description = existingData.Movie.Description,
                    Genre = new GenreDto
                    {
                        Id = existingData.Movie.Genre.Id,
                        Name = existingData.Movie.Genre.Name,
                        IsActive = existingData.Movie.Genre.IsActive,
                        CreatedAt = existingData.Movie.Genre.CreatedAt,
                        UpdatedAt = existingData.Movie.Genre.UpdatedAt
                    },
                    CreatedAt = existingData.Movie.CreatedAt,
                    UpdatedAt = existingData.Movie.UpdatedAt
                },
                Studio = new StudioDto
                {
                    Id = existingData.Studio.Id,
                    Name = existingData.Studio.Name,
                    Capacity = existingData.Studio.Capacity,
                    CreatedAt = existingData.Studio.CreatedAt,
                    UpdatedAt = existingData.Studio.UpdatedAt
                },
                DateTime = existingData.DateTime,
                Price = existingData.Price,
                CreatedAt = existingData.CreatedAt,
                UpdatedAt = existingData.UpdatedAt
            });
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
