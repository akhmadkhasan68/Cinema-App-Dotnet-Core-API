using CinemaApp.Dtos.Genre;
using CinemaApp.Infrastructures.Responses;
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
        public async Task<ActionResult<ApiResponse<List<GenreResponseDto>>>> GetAll()
        {
            var genres = await _genreService.GetAll();

            return Ok(ApiResponse<List<GenreResponseDto>>.Success(genres.Select(genre => genre.ToResponse()).ToList()));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<GenreResponseDto>>> FindOne([FromRoute] int id)
        {
            var genre = await _genreService.FindOne(id);

            return Ok(ApiResponse<GenreResponseDto>.Success(genre.ToResponse()));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create([FromBody] GenreRequestDto genreRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _genreService.CreateAsync(genreRequestDto.ToModel());

            return Ok(ApiResponse.Success("Genre created successfully"));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse>> Update([FromRoute] int id, [FromBody] GenreRequestDto genreRequestDto)
        {
            await _genreService.UpdateAsync(id, genreRequestDto.ToModel());

            return Ok(ApiResponse.Success("Genre updated successfully"));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete([FromRoute] int id)
        {
            var isDeleted = await _genreService.Delete(id);

            return Ok(ApiResponse<bool>.Success(isDeleted));
        }
    }
}
