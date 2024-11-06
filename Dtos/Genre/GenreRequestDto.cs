using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Dtos.Genre
{
    public class GenreRequestDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; set; } = true;
    }
}
