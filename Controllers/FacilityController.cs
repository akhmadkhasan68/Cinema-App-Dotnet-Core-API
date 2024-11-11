using CinemaApp.Dtos.Facility;
using CinemaApp.Dtos.Pagination;
using CinemaApp.Infrastructures.Responses;
using CinemaApp.Interfaces.Services;
using CinemaApp.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    [ApiController]
    [Route("api/facilities")]
    public class FacilityController(IFacilityService facilityService) : ControllerBase
    {   
        private readonly IFacilityService _facilityService = facilityService;

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<PaginateResponse<FacilityResponseDto>>> GetFacilities([FromQuery] PaginationRequestDto paginationRequestDto)
        {
            var facilities = await _facilityService.GetAll(paginationRequestDto);

            return Ok(PaginateResponse<FacilityResponseDto>.Success(
                facilities.Select(facility => facility.ToResponse()).ToList(), 
                paginationRequestDto.Page,
                paginationRequestDto.PerPage,
                facilities.Count
            ));
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<FacilityResponseDto>>> GetFacility([FromRoute] int id)
        {
            var facility = await _facilityService.FindOne(id);

            return Ok(ApiResponse<FacilityResponseDto>.Success(facility.ToResponse()));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ApiResponse>> AddFacility([FromBody] FacilityRequestDto facilityRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _facilityService.CreateAsync(facilityRequestDto.ToModel());
            
            return Ok(ApiResponse.Success("Facility created successfully"));
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse>> UpdateFacility([FromRoute] int id, [FromBody] FacilityRequestDto facilityRequestDto)
        {
            await _facilityService.UpdateAsync(id, facilityRequestDto.ToModel());
            
            return Ok(ApiResponse.Success("Facility updated successfully"));
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteFacility([FromRoute] int id)
        {
            var isDeleted = await _facilityService.Delete(id);
            
            return Ok(ApiResponse<bool>.Success(isDeleted));
        }
    }
}
