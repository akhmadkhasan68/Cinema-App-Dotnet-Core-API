using CinemaApp.Dtos.Movie;
using CinemaApp.Infrastructures.Responses;
using CinemaApp.Interfaces.Responses;
using CinemaApp.Interfaces.Services;
using CinemaApp.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController(IMovieService movieService) : ControllerBase
    {
        private readonly IMovieService _movieService = movieService;

        [HttpGet]
        public async Task<ActionResult<IApiResponse<List<MovieResponseDto>>>> GetMovies()
        {
            var movies = await _movieService.GetAll();

            return Ok(ApiResponse<List<MovieResponseDto>>.Success(movies.Select(movie => movie.ToResponse()).ToList()));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IApiResponse<MovieResponseDto>>> GetMovie([FromRoute] int id)
        {
            var movie = await _movieService.FindOne(id);

            return Ok(ApiResponse<MovieResponseDto>.Success(movie.ToResponse()));
        }

        [HttpPost]
        public async Task<ActionResult<IApiResponse<MovieResponseDto>>> AddMovie([FromBody] MovieRequestDto movieRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newMovie = await _movieService.Create(movieRequestDto);

            return Ok(ApiResponse<MovieResponseDto>.Success(newMovie.ToResponse()));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<IApiResponse<MovieResponseDto>>> UpdateMovie([FromRoute] int id, [FromBody] MovieRequestDto movieRequestDto)
        {
            var updatedMovie = await _movieService.Update(id, movieRequestDto);

            return Ok(ApiResponse<MovieResponseDto>.Success(updatedMovie.ToResponse()));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<IApiResponse<bool>>> DeleteMovie([FromRoute] int id)
        {
            var isDeleted = await _movieService.Delete(id);

            return Ok(ApiResponse<bool>.Success(isDeleted));
        }
    }
}
