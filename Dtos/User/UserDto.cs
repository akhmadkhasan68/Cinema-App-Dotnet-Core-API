using CinemaApp.Dtos.Role;

namespace CinemaApp.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string Name { get; set; }
        
        public int RoleId { get; set; }

        public RoleDto? Role { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
