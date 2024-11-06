using CinemaApp.Dtos.Genre;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Models;

namespace CinemaApp.Services
{
    public class GenreService(IGenreRepository genreRepository) : IGenreService
    {
        private readonly IGenreRepository _genreRepository = genreRepository;

        public Task<List<GenreDto>> GetAll()
        {
            return _genreRepository.GetAll();
        }

        public Task<GenreDto> FindOne(int id)
        {
            return _genreRepository.FindOne(id);
        }

        public Task<GenreDto> Create(Genre data)
        {
            return _genreRepository.Create(data);
        }

        public Task<GenreDto> Update(int id, Genre data)
        {
            return _genreRepository.Update(id, data);
        }

        public Task<bool> Delete(int id)
        {
            return _genreRepository.Delete(id);
        }
    }
}
