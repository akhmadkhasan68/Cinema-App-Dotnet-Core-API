using CinemaApp.Dtos.Studio;
using CinemaApp.Infrastructures.Responses;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.Services;
using CinemaApp.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers;

[ApiController]
[Route("api/studios")]
public class StudioController(IStudioService studioService) : ControllerBase {
    private readonly IStudioService _studioService = studioService;

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<StudioResponseDto>>>> GetStudios() {
        var studios = await _studioService.GetAll();

        return Ok(ApiResponse<List<StudioResponseDto>>.Success(studios.Select(studio => studio.ToResponse()).ToList()));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<StudioResponseDto>>> GetStudio([FromRoute] int id) {
        var studio = await _studioService.FindOne(id);

        return Ok(ApiResponse<StudioResponseDto>.Success(studio.ToResponse()));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<StudioResponseDto>>> AddStudio([FromBody] StudioRequestDto studioRequestDto) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        var newStudio = await _studioService.Create(studioRequestDto.ToModel());
        
        return Ok(ApiResponse<StudioResponseDto>.Success(newStudio.ToResponse()));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ApiResponse<StudioResponseDto>>> UpdateStudio([FromRoute] int id, [FromBody] StudioRequestDto studioRequestDto) {
        var updatedStudio = await _studioService.Update(id, studioRequestDto.ToModel());
        
        return Ok(ApiResponse<StudioResponseDto>.Success(updatedStudio.ToResponse()));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteStudio([FromRoute] int id) {
        var isDeleted = await _studioService.Delete(id);
        
        return Ok(ApiResponse<bool>.Success(isDeleted));
    }
}
