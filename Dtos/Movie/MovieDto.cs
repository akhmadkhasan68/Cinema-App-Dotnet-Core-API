using CinemaApp.Dtos.Genre;

namespace CinemaApp.Dtos.Movie
{
    public class MovieDto
    {
        public int Id { get; set; }

        public int GenreId { get; set; }

        public string Title { get; set; } = null!;

        public int DurationInMinutes { get; set; }

        public string Description { get; set; } = null!;

        public GenreDto? Genre { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
