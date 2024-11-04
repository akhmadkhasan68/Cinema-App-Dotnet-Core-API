using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Dtos.Studio
{
    public class StudioRequestDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
        [MaxLength(50, ErrorMessage = "Name must be at most 50 characters long")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Capacity is required")]
        [Range(1, 1000, ErrorMessage = "Capacity must be between 1 and 1000")]
        public int Capacity { get; set; }
    }
}
