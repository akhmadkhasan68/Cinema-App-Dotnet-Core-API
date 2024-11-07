using CinemaApp.Dtos.Facility;
using CinemaApp.Infrastructures.Responses;
using CinemaApp.Interfaces.Responses;
using CinemaApp.Interfaces.Services;
using CinemaApp.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    [ApiController]
    [Route("api/facilities")]
    public class FacilityController(IFacilityService facilityService) : ControllerBase
    {   
        private readonly IFacilityService _facilityService = facilityService;

        [HttpGet]
        public async Task<ActionResult<IApiResponse<List<FacilityResponseDto>>>> GetFacilities()
        {
            var facilities = await _facilityService.GetAll();

            return Ok(ApiResponse<List<FacilityResponseDto>>.Success(facilities.Select(facility => facility.ToResponse()).ToList()));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IApiResponse<FacilityResponseDto>>> GetFacility([FromRoute] int id)
        {
            var facility = await _facilityService.FindOne(id);

            return Ok(ApiResponse<FacilityResponseDto>.Success(facility.ToResponse()));
        }

        [HttpPost]
        public async Task<ActionResult<IApiResponse<FacilityResponseDto>>> AddFacility([FromBody] FacilityRequestDto facilityRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newFacility = await _facilityService.Create(facilityRequestDto.ToModel());
            
            return Ok(ApiResponse<FacilityResponseDto>.Success(newFacility.ToResponse()));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<IApiResponse<FacilityResponseDto>>> UpdateFacility([FromRoute] int id, [FromBody] FacilityRequestDto facilityRequestDto)
        {
            var updatedFacility = await _facilityService.Update(id, facilityRequestDto.ToModel());
            
            return Ok(ApiResponse<FacilityResponseDto>.Success(updatedFacility.ToResponse()));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<IApiResponse<bool>>> DeleteFacility([FromRoute] int id)
        {
            var isDeleted = await _facilityService.Delete(id);
            
            return Ok(ApiResponse<bool>.Success(isDeleted));
        }
    }
}
