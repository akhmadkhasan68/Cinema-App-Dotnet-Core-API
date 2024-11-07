using CinemaApp.Dtos.Genre;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Models;

namespace CinemaApp.Services
{
    public class GenreService(
        IGenreRepository genreRepository,
        ILogger<GenreService> logger
    ) : IGenreService
    {
        private readonly IGenreRepository _genreRepository = genreRepository;
        
        private readonly ILogger<GenreService> _logger = logger;

        public Task<List<GenreDto>> GetAll()
        {
            _logger.LogInformation("Get all genres");

            return _genreRepository.GetAll();
        }

        public Task<GenreDto> FindOne(int id)
        {
            _logger.LogInformation("Find one genre");

            return _genreRepository.FindOne(id);
        }

        public Task<GenreDto> Create(Genre data)
        {
            _logger.LogInformation("Create genre");

            return _genreRepository.Create(data);
        }

        public Task<GenreDto> Update(int id, Genre data)
        {
            _logger.LogInformation("Update genre");

            return _genreRepository.Update(id, data);
        }

        public Task<bool> Delete(int id)
        {
            _logger.LogInformation("Delete genre");
            
            return _genreRepository.Delete(id);
        }
    }
}
