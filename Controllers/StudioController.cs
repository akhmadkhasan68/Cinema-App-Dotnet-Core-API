using CinemaApp.Dtos.Studio;
using CinemaApp.Infrastructures.Responses;
using CinemaApp.Interfaces;
using CinemaApp.Mappers;
using CinemaApp.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers;

[ApiController]
[Route("api/studios")]
public class StudioController(ILogger<StudioController> logger, IStudioRepository studioRepository) : ControllerBase {
    private readonly ILogger<StudioController> _logger = logger;
    private readonly IStudioRepository _studioRepository = studioRepository;

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<StudioResponseDto>>>> GetStudios() {
        var studios = await _studioRepository.GetAll();

        return Ok(ApiResponse<List<StudioResponseDto>>.Success(studios.Select(studio => studio.ToResponse()).ToList()));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<StudioResponseDto>>> GetStudio(int id) {
        var studio = await _studioRepository.FindOne(id);

        return Ok(ApiResponse<StudioResponseDto>.Success(studio.ToResponse()));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<StudioResponseDto>>> AddStudio(StudioRequestDto studioRequestDto) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        var newStudio = await _studioRepository.Create(studioRequestDto.ToModel());
        
        return Ok(ApiResponse<StudioResponseDto>.Success(newStudio.ToResponse()));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ApiResponse<StudioResponseDto>>> UpdateStudio(int id, StudioRequestDto studioRequestDto) {
        var updatedStudio = await _studioRepository.Update(id, studioRequestDto.ToModel());
        
        return Ok(ApiResponse<StudioResponseDto>.Success(updatedStudio.ToResponse()));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteStudio(int id) {
        var isDeleted = await _studioRepository.Delete(id);
        
        return Ok(ApiResponse<bool>.Success(isDeleted));
    }
}
