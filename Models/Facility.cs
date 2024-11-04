namespace CinemaApp.Models;

public class Facility : BaseModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    public List<Studio> Studios { get; } = [];
}
