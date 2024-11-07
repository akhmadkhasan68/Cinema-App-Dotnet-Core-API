using CinemaApp.Dtos.Permission;
using CinemaApp.Dtos.Role;

namespace CinemaApp.Dtos.RolePermission
{
    public class RolePermissionDto
    {
        public int RoleId { get; set; }

        public RoleDto? Role { get; set; }

        public int PermissionId { get; set; }
        
        public PermissionDto? Permission { get; set; }
    }
}
