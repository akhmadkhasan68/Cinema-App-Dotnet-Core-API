namespace CinemaApp.Models;

public class Permission : BaseModel
{
    public int Id { get; set; }

    public string Key { get; set; } = null!;   
    
    public string Name { get; set; } = null!;   

    public List<RolePermission> RolePermissions { get; set; }
}
