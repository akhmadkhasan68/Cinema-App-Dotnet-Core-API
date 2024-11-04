namespace CinemaApp.Models;

public class User : BaseModel
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int RoleId { get; set; }

    public Role Role { get; set; } = null!;
}
