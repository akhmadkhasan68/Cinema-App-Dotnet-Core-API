using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Genre;
using CinemaApp.Dtos.Pagination;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Models;

namespace CinemaApp.Services
{
    public class GenreService(IGenreRepository genreRepository) : IGenreService
    {
        private readonly IGenreRepository _genreRepository = genreRepository;

        public async Task<List<GenreDto>> GetAll(PaginationRequestDto paginationRequestDto)
        {
            return await _genreRepository.GetAll(paginationRequestDto);
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
