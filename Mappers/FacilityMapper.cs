using CinemaApp.Dtos.Facility;
using CinemaApp.Models;

namespace CinemaApp.Mappers
{
    public static class FacilityMapper
    {
        public static FacilityDto ToDto(this Facility studio)
        {
            return new FacilityDto
            {
                Id = studio.Id,
                Name = studio.Name,
                IsActive = studio.IsActive,
                CreatedAt = studio.CreatedAt,
                UpdatedAt = studio.UpdatedAt,
            };
        }   

        public static FacilityResponseDto ToResponse(this FacilityDto facilityDto)
        {
            return new FacilityResponseDto
            {
                Id = facilityDto.Id,
                Name = facilityDto.Name,
                IsActive = facilityDto.IsActive,
                CreatedAt = facilityDto.CreatedAt,
                UpdatedAt = facilityDto.UpdatedAt,
            };
        }     

        public static Facility ToModel(this FacilityRequestDto facilityRequestDto)
        {
            return new Facility
            {
                Name = facilityRequestDto.Name,
                IsActive = facilityRequestDto.IsActive,
            };
        }
    }
}
