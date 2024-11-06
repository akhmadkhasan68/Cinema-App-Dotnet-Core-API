using CinemaApp.Dtos.Movie;
using CinemaApp.Models;

namespace CinemaApp.Interfaces.Repositories
{
    public interface IMovieRepository : IBaseRepository<MovieDto, Movie> {}
}
