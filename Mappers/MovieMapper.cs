using CinemaApp.Dtos.Movie;
using CinemaApp.Models;

namespace CinemaApp.Mappers
{
    public static class MovieMapper
    {
        public static MovieDto ToDto(this Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                GenreId = movie.GenreId,
                Title = movie.Title,
                DurationInMinutes = movie.DurationInMinutes,
                Description = movie.Description,
                Genre = movie.Genre?.ToDto() ?? null,
                CreatedAt = movie.CreatedAt,
                UpdatedAt = movie.UpdatedAt,
            };
        }   

        public static MovieResponseDto ToResponse(this MovieDto movieDto)
        {
            return new MovieResponseDto
            {
                Id = movieDto.Id,
                Title = movieDto.Title,
                DurationInMinutes = movieDto.DurationInMinutes,
                Description = movieDto.Description,
                Genre = movieDto.Genre?.ToResponse() ?? null,
                CreatedAt = movieDto.CreatedAt,
                UpdatedAt = movieDto.UpdatedAt,
            };
        }     

        public static Movie ToModel(this MovieRequestDto movieRequestDto)
        {
            return new Movie
            {
                Title = movieRequestDto.Title,
                GenreId = movieRequestDto.GenreId,
                DurationInMinutes = movieRequestDto.DurationInMinutes,
                Description = movieRequestDto.Description,
            };
        }
    }
}
