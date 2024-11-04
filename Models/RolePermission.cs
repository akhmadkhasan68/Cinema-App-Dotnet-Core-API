namespace CinemaApp.Models;

public class RolePermission : BaseModel
{
    public int RoleId { get; set; }

    public int PermissionId { get; set; }

    public Role Role { get; set; } = null!;

    public Permission Permission { get; set; } = null!;
}
