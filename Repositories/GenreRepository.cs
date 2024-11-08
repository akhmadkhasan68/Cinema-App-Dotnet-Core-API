using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Genre;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Infrastructures.Exceptions;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Mappers;
using CinemaApp.Models;

namespace CinemaApp.Repositories
{
    public class GenreRepository(ApplicationDBContext applicationDBContext) : IGenreRepository
    {
        private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;

        public Task<List<GenreDto>> GetAll()
        {
            var datas = _applicationDBContext.Genres.ToList();

            return Task.FromResult(datas.Select(data => data.ToDto()).ToList());
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
