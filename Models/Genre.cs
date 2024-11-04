namespace CinemaApp.Models;

public class Genre : BaseModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    public List<Movie> Movies { get; } = [];
}
