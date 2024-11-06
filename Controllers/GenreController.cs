using CinemaApp.Dtos.Genre;
using CinemaApp.Infrastructures.Responses;
using CinemaApp.Interfaces.Responses;
using CinemaApp.Interfaces.Services;
using CinemaApp.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenreController(IGenreService genreService) : ControllerBase
    {
        private readonly IGenreService _genreService = genreService;

        [HttpGet]
        public async Task<ActionResult<IApiResponse<List<GenreResponseDto>>>> GetAll()
        {
            var genres = await _genreService.GetAll();

            return Ok(ApiResponse<List<GenreResponseDto>>.Success(genres.Select(genre => genre.ToResponse()).ToList()));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IApiResponse<GenreResponseDto>>> FindOne([FromRoute] int id)
        {
            var genre = await _genreService.FindOne(id);

            return Ok(ApiResponse<GenreResponseDto>.Success(genre.ToResponse()));
        }

        [HttpPost]
        public async Task<ActionResult<IApiResponse<GenreResponseDto>>> Create([FromBody] GenreRequestDto genreRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newGenre = await _genreService.Create(genreRequestDto.ToModel());

            return Ok(ApiResponse<GenreResponseDto>.Success(newGenre.ToResponse()));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<IApiResponse<GenreResponseDto>>> Update([FromRoute] int id, [FromBody] GenreRequestDto genreRequestDto)
        {
            var updatedGenre = await _genreService.Update(id, genreRequestDto.ToModel());

            return Ok(ApiResponse<GenreResponseDto>.Success(updatedGenre.ToResponse()));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<IApiResponse<bool>>> Delete([FromRoute] int id)
        {
            var isDeleted = await _genreService.Delete(id);

            return Ok(ApiResponse<bool>.Success(isDeleted));
        }
    }
}
