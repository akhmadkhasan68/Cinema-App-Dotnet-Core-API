using CinemaApp.Dtos;
using CinemaApp.Dtos.Studio;
using CinemaApp.Models;
using CinemaApp.Responses;

namespace CinemaApp.Mappers
{
    public static class StudioMapper
    {
        public static StudioDto ToDto(this Studio studio)
        {
            return new StudioDto
            {
                Id = studio.Id,
                Name = studio.Name,
                Capacity = studio.Capacity,
                StudioFacilities = studio.StudioFacilities,
                CreatedAt = studio.CreatedAt,
                UpdatedAt = studio.UpdatedAt,
            };
        }   

        public static StudioResponseDto ToResponse(this StudioDto studioDto)
        {
            return new StudioResponseDto
            {
                Id = studioDto.Id,
                Name = studioDto.Name,
                Capacity = studioDto.Capacity,
                CreatedAt = studioDto.CreatedAt,
                UpdatedAt = studioDto.UpdatedAt,
            };
        }     

        public static Studio ToModel(this StudioRequestDto studioRequestDto)
        {
            return new Studio
            {
                Name = studioRequestDto.Name,
                Capacity = studioRequestDto.Capacity,
            };
        }
    }
}
