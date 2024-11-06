using CinemaApp.Dtos.Genre;
using CinemaApp.Infrastructures.Database;
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
            var data = _applicationDBContext.Genres.Find(id) ?? throw new Exception("Data not found");

            return Task.FromResult(data.ToDto());
        }

        public Task<bool> IsExist(int id)
        {
            return Task.FromResult(_applicationDBContext.Genres.Any(data => data.Id == id));
        }

        public Task<GenreDto> Create(Genre data)
        {
            _applicationDBContext.Genres.Add(data);
            _applicationDBContext.SaveChanges();

            return Task.FromResult(data.ToDto());
        }

        public Task<GenreDto> Update(int id, Genre data)
        {
            var currentData = _applicationDBContext.Genres.Find(id) ?? throw new Exception("Data not found");

            currentData.Name = data.Name;
            currentData.IsActive = data.IsActive;

            _applicationDBContext.SaveChanges();

            return Task.FromResult(currentData.ToDto());
        }

        public Task<bool> Delete(int id)
        {
            var currentData = _applicationDBContext.Genres.Find(id) ?? throw new Exception("Data not found");

            _applicationDBContext.Genres.Remove(currentData);
            _applicationDBContext.SaveChanges();

            return Task.FromResult(true);
        }

    }
}
