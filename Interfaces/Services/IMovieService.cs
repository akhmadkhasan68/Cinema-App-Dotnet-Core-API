using CinemaApp.Dtos.Movie;

namespace CinemaApp.Interfaces.Services
{
    public interface IMovieService : IBaseService<MovieDto, MovieRequestDto> {}
}
