namespace CinemaApp.Models;
public class Studio : BaseModel
{
    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public List<StudioFacility> StudioFacilities { get; } = [];
}
