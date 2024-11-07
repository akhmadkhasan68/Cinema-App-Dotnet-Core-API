using CinemaApp.Dtos.RolePermission;

namespace CinemaApp.Dtos.Permission
{
    public class PermissionDto
    {
        public int Id { get; set; }

        public string Key { get; set; } = null!;

        public string Name { get; set; } = null!;

        public List<RolePermissionDto> RolePermissions { get; set; } = [];

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
