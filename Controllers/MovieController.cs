using CinemaApp.Dtos.Movie;
using CinemaApp.Dtos.Pagination;
using CinemaApp.Infrastructures.Responses;
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
        public async Task<ActionResult<PaginateResponse<MovieResponseDto>>> GetMovies([FromQuery] PaginationRequestDto paginationRequestDto)
        {
            var movies = await _movieService.GetAll(paginationRequestDto);

            return Ok(PaginateResponse<MovieResponseDto>.Success(
                movies.Select(movie => movie.ToResponse()).ToList(),
                paginationRequestDto.Page,
                paginationRequestDto.PerPage,
                movies.Count
            ));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<MovieResponseDto>>> GetMovie([FromRoute] int id)
        {
            var movie = await _movieService.FindOne(id);

            return Ok(ApiResponse<MovieResponseDto>.Success(movie.ToResponse()));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddMovie([FromBody] MovieRequestDto movieRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _movieService.CreateAsync(movieRequestDto);

            return Ok(ApiResponse.Success("Movie created successfully"));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse>> UpdateMovie([FromRoute] int id, [FromBody] MovieRequestDto movieRequestDto)
        {
            await _movieService.UpdateAsync(id, movieRequestDto);

            return Ok(ApiResponse.Success("Movie updated successfully"));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteMovie([FromRoute] int id)
        {
            var isDeleted = await _movieService.Delete(id);

            return Ok(ApiResponse<bool>.Success(isDeleted));
        }
    }
}
