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
        public async Task<ActionResult<ApiResponse<List<ScheduleResponseDto>>>> GetStudios() {
            var datas = await _scheduleService.GetAll();

            return Ok(ApiResponse<List<ScheduleResponseDto>>.Success(datas.Select(data => data.ToResponse()).ToList()));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<ScheduleResponseDto>>> GetStudio([FromRoute] int id) {
            var data = await _scheduleService.FindOne(id);

            return Ok(ApiResponse<ScheduleResponseDto>.Success(data.ToResponse()));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<ScheduleResponseDto>>> AddStudio([FromBody] ScheduleRequestDto scheduleRequestDto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var newData = await _scheduleService.Create(scheduleRequestDto);
            
            return Ok(ApiResponse<ScheduleResponseDto>.Success(newData.ToResponse()));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<ScheduleResponseDto>>> UpdateStudio([FromRoute] int id, [FromBody] ScheduleRequestDto scheduleRequestDto) {
            var updatedData = await _scheduleService.Update(id, scheduleRequestDto);
            
            return Ok(ApiResponse<ScheduleResponseDto>.Success(updatedData.ToResponse()));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteStudio([FromRoute] int id) {
            var isDeleted = await _scheduleService.Delete(id);
            
            return Ok(ApiResponse<bool>.Success(isDeleted));
        }
    }
}
