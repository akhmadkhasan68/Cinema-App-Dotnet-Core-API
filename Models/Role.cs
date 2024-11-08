namespace CinemaApp.Models;

public class Role : BaseModel
{
    public string Key { get; set; } = null!;
    
    public string Name { get; set; } = null!;

    public ICollection<RolePermission> RolePermissions { get; set; } = [];

    public ICollection<User> Users { get; } = [];
}
