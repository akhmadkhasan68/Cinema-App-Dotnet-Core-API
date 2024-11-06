using CinemaApp.Dtos.Genre;
using CinemaApp.Models;

namespace CinemaApp.Mappers
{
    public static class GenreMapper
    {
        public static GenreDto ToDto(this Genre genre)
        {
            return new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name,
                IsActive = genre.IsActive,
                CreatedAt = genre.CreatedAt,
                UpdatedAt = genre.UpdatedAt,
            };
        }   

        public static GenreResponseDto ToResponse(this GenreDto genreDto)
        {
            return new GenreResponseDto
            {
                Id = genreDto.Id,
                Name = genreDto.Name,
                IsActive = genreDto.IsActive,
                CreatedAt = genreDto.CreatedAt,
                UpdatedAt = genreDto.UpdatedAt,
            };
        }     

        public static Genre ToModel(this GenreRequestDto genreRequestDto)
        {
            return new Genre
            {
                Name = genreRequestDto.Name,
                IsActive = genreRequestDto.IsActive,
            };
        }
    }
}
