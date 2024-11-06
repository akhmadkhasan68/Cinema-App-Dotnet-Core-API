using CinemaApp.Dtos.Genre;
using CinemaApp.Models;

namespace CinemaApp.Interfaces.Services
{
    public interface IGenreService : IBaseService<GenreDto, Genre> {}
}
