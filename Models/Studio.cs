namespace CinemaApp.Models;
public class Studio : BaseModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public List<Facility> Facilities { get; } = [];
}
