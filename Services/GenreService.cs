using System.Runtime.CompilerServices;
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

        public async Task<AsyncVoidMethodBuilder> CreateAsync(Genre data)
        {
            return await _genreRepository.CreateAsync(data);
        }

        public async Task<AsyncVoidMethodBuilder> UpdateAsync(int id, Genre data)
        {
            return await _genreRepository.UpdateAsync(id, data);
        }

        public Task<bool> Delete(int id)
        {   
            return _genreRepository.Delete(id);
        }
    }
}
