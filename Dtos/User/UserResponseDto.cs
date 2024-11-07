using CinemaApp.Dtos.Role;

namespace CinemaApp.Dtos.User
{
    public class UserResponseDto
    {
        public int Id { get; set; }

        public string Email { get; set; } = null!;

        public string Name { get; set; } = null!;

        public RoleResponseDto? Role { get; set; }

        public DateTime RegisteredAt { get; set; }
    }
}
