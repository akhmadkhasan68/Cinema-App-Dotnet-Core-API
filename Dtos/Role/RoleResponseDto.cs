using CinemaApp.Dtos.Permission;

namespace CinemaApp.Dtos.Role
{
    public class RoleResponseDto
    {
        public int Id { get; set; }
        
        public string Key { get; set; } = null!;
        
        public string Name { get; set; } = null!;

        public ICollection<PermissionResponseDto> Permissions { get; set; } = [];
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; } 
    }
}
