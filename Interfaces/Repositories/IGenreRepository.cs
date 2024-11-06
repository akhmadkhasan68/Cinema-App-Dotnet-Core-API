using CinemaApp.Dtos.Genre;
using CinemaApp.Models;

namespace CinemaApp.Interfaces.Repositories
{
    public interface IGenreRepository : IBaseRepository<GenreDto, Genre> {
        public Task<bool> IsExist(int id);
    }
}
