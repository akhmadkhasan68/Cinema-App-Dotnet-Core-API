namespace CinemaApp.Models;

public class Movie : BaseModel
{
    public int Id { get; set; }

    public int GenreId { get; set; }

    public string Title { get; set; } = null!;

    public int DurationInMinutes { get; set; }

    public string Description { get; set; } = null!;

    public Genre Genre { get; set; }
}
