namespace CinemaApp.Models;

public class Schedule : BaseModel
{
    public int StudioId { get; set; }

    public int MovieId { get; set; }

    public DateTime DateTime { get; set; }

    public int Price { get; set; }

    public Studio Studio { get; set; } = null!;

    public Movie Movie { get; set; } = null!;
}
