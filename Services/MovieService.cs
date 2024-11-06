using CinemaApp.Dtos.Movie;
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

        public Task<List<MovieDto>> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public Task<MovieDto> FindOne(int id)
        {
            return _movieRepository.FindOne(id);
        }

        public async Task<MovieDto> Create(MovieRequestDto data)
        {
            var IsExist = await _genreRepository.IsExist(data.GenreId);

            if (!IsExist) throw new Exception("Genre not found");

            return await _movieRepository.Create(data.ToModel());
        }

        public async Task<MovieDto> Update(int id, MovieRequestDto data)
        {
            var IsExist = await _genreRepository.IsExist(data.GenreId);

            if (!IsExist) throw new Exception("Genre not found");

            return await _movieRepository.Update(id, data.ToModel());
        }

        public Task<bool> Delete(int id)
        {
            return _movieRepository.Delete(id);
        }
    }
}
