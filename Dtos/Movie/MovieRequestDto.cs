using System.ComponentModel.DataAnnotations;
using CinemaApp.Dtos.Genre;

namespace CinemaApp.Dtos.Movie
{
    public class MovieRequestDto
    {
        [Required(ErrorMessage = "GenreId is required")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "DurationInMinutes is required")]
        [DataType(DataType.Duration)]
        public int DurationInMinutes { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = null!;
    }
}
