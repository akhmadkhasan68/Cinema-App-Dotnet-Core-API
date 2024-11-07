using CinemaApp.Dtos.Permission;
using CinemaApp.Dtos.Role;

namespace CinemaApp.Dtos.RolePermission
{
    public class RolePermissionResponseDto
    {   
        public RoleResponseDto? Role { get; set; }
        
        public PermissionResponseDto? Permission { get; set; }
    }
}
