using CinemaApp.Dtos.Auth;
using CinemaApp.Dtos.User;

namespace CinemaApp.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<AuthLoginResponseDto> LoginAsync(AuthLoginRequestDto authLoginRequestDto);

        public Task<UserResponseDto> RegisterAsync(UserRequestDto userRequestDto);
    }
}
