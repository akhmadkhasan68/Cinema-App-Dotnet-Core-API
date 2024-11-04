namespace CinemaApp.Models;
public class StudioFacility : BaseModel
{
    public int StudioId { get; set; }

    public int FacilityId { get; set; }

    public Studio Studio { get; set; } = null!;

    public Facility Facility { get; set; } = null!;
}
