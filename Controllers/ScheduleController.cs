using CinemaApp.Dtos.Pagination;
using CinemaApp.Dtos.Schedule;
using CinemaApp.Infrastructures.Responses;
using CinemaApp.Interfaces.Services;
using CinemaApp.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    [ApiController]
    [Route("api/schedules")]
    public class ScheduleController(IScheduleService scheduleService) : ControllerBase
    {
        private readonly IScheduleService _scheduleService = scheduleService;

        [HttpGet]
        public async Task<ActionResult<PaginateResponse<ScheduleResponseDto>>> GetStudios([FromQuery] PaginationRequestDto paginationRequestDto) {
            var datas = await _scheduleService.GetAll(paginationRequestDto);

            return Ok(PaginateResponse<ScheduleResponseDto>.Success(
                datas.Select(data => data.ToResponse()).ToList(),
                paginationRequestDto.Page,
                paginationRequestDto.PerPage,
                datas.Count
            ));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<ScheduleResponseDto>>> GetStudio([FromRoute] int id) {
            var data = await _scheduleService.FindOne(id);

            return Ok(ApiResponse<ScheduleResponseDto>.Success(data.ToResponse()));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddStudio([FromBody] ScheduleRequestDto scheduleRequestDto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            await _scheduleService.CreateAsync(scheduleRequestDto);
            
            return Ok(ApiResponse.Success("Schedule created successfully"));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<ScheduleResponseDto>>> UpdateStudio([FromRoute] int id, [FromBody] ScheduleRequestDto scheduleRequestDto) {
            await _scheduleService.UpdateAsync(id, scheduleRequestDto);
            
            return Ok(ApiResponse<ScheduleResponseDto>.Success("Schedule updated successfully"));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteStudio([FromRoute] int id) {
            var isDeleted = await _scheduleService.Delete(id);
            
            return Ok(ApiResponse<bool>.Success(isDeleted));
        }
    }
}
