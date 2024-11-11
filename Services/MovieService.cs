using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Movie;
using CinemaApp.Dtos.Pagination;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Mappers;

namespace CinemaApp.Services
{
    public class MovieService(
        IMovieRepository movieRepository,
        IGenreRepository genreRepository
    ) : IMovieService
    {
        public readonly IMovieRepository _movieRepository = movieRepository;
        public readonly IGenreRepository _genreRepository = genreRepository;

        public async Task<List<MovieDto>> GetAll(PaginationRequestDto paginationRequestDto)
        {
            return await _movieRepository.GetAll(paginationRequestDto);
        }

        public Task<MovieDto> FindOne(int id)
        {
            return _movieRepository.FindOne(id);
        }

        public async Task<AsyncVoidMethodBuilder> CreateAsync(MovieRequestDto data)
        {
            var IsExist = await _genreRepository.IsExist(data.GenreId);

            if (!IsExist) throw new Exception("Genre not found");

            return await _movieRepository.CreateAsync(data.ToModel());
        }

        public async Task<AsyncVoidMethodBuilder> UpdateAsync(int id, MovieRequestDto data)
        {
            var IsExist = await _genreRepository.IsExist(data.GenreId);

            if (!IsExist) throw new Exception("Genre not found");

            return await _movieRepository.UpdateAsync(id, data.ToModel());
        }

        public Task<bool> Delete(int id)
        {
            return _movieRepository.Delete(id);
        }
    }
}
