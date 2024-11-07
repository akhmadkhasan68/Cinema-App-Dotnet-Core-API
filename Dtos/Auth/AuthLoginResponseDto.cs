using CinemaApp.Dtos.User;

namespace CinemaApp.Dtos.Auth
{
    public class AuthLoginResponseDto
    {
        public UserResponseDto User { get; set; } = null!;

        public string AccessToken { get; set; } = null!;
    }
}
