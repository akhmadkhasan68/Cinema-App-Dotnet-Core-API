namespace CinemaApp.Models;

public class Facility : BaseModel
{
    public string Name { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    public ICollection<StudioFacility> StudioFacilities { get; } = [];
}
