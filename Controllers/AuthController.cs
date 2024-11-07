using CinemaApp.Dtos.Auth;
using CinemaApp.Dtos.User;
using CinemaApp.Infrastructures.Responses;
using CinemaApp.Interfaces.Responses;
using CinemaApp.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("login")]
        public async Task<ActionResult<IApiResponse<AuthLoginResponseDto>>> Login([FromBody] AuthLoginRequestDto authLoginRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loginResponse = await _authService.LoginAsync(authLoginRequestDto);

            Response.Headers.Append("Authorization", $"Bearer {loginResponse.AccessToken}");

            return Ok(ApiResponse<AuthLoginResponseDto>.Success(loginResponse));
        }

        [HttpPost("register")]
        public async Task<ActionResult<IApiResponse<UserResponseDto>>> Register([FromBody]  UserRequestDto userRequestDto)
        {
            var registerResponse = await _authService.RegisterAsync(userRequestDto);

            return Ok(ApiResponse<UserResponseDto>.Success(registerResponse));
        }
    }
}
