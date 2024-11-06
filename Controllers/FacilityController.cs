using CinemaApp.Dtos.Facility;
using CinemaApp.Infrastructures.Responses;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Responses;
using CinemaApp.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    [ApiController]
    [Route("api/facilities")]
    public class FacilityController(ILogger<FacilityController> logger, IFacilityRepository facilityRepository) : ControllerBase
    {   
        private readonly ILogger<FacilityController> _logger = logger;
        private readonly IFacilityRepository _studioRepository = facilityRepository;

        [HttpGet]
        public async Task<ActionResult<IApiResponse<List<FacilityResponseDto>>>> GetFacilities()
        {
            var facilities = await _studioRepository.GetAll();

            return Ok(ApiResponse<List<FacilityResponseDto>>.Success(facilities.Select(facility => facility.ToResponse()).ToList()));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IApiResponse<FacilityResponseDto>>> GetFacility(int id)
        {
            var facility = await _studioRepository.FindOne(id);

            return Ok(ApiResponse<FacilityResponseDto>.Success(facility.ToResponse()));
        }

        [HttpPost]
        public async Task<ActionResult<IApiResponse<FacilityResponseDto>>> AddFacility(FacilityRequestDto facilityRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newFacility = await _studioRepository.Create(facilityRequestDto.ToModel());
            
            return Ok(ApiResponse<FacilityResponseDto>.Success(newFacility.ToResponse()));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<IApiResponse<FacilityResponseDto>>> UpdateFacility(int id, FacilityRequestDto facilityRequestDto)
        {
            var updatedFacility = await _studioRepository.Update(id, facilityRequestDto.ToModel());
            
            return Ok(ApiResponse<FacilityResponseDto>.Success(updatedFacility.ToResponse()));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<IApiResponse<bool>>> DeleteFacility(int id)
        {
            var isDeleted = await _studioRepository.Delete(id);
            
            return Ok(ApiResponse<bool>.Success(isDeleted));
        }
    }
}
