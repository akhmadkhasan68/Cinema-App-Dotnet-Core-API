namespace CinemaApp.Models;

public class Role : BaseModel
{
    public int Id { get; set; }

    public string Key { get; set; } = null!;
    
    public string Name { get; set; } = null!;

    public List<RolePermission> RolePermissions { get; set; }

    public List<User> Users { get; } = [];
}
