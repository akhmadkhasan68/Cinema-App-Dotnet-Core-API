namespace CinemaApp.Models;

public class Genre : BaseModel
{
    public string Name { get; set; } = null!;

    public bool IsActive { get; set; } = true;

    public ICollection<Movie> Movies { get; } = [];
}
