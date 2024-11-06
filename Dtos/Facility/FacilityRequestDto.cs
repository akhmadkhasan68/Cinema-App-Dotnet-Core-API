using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Dtos.Facility
{
    public class FacilityRequestDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
        [MaxLength(50, ErrorMessage = "Name must be at most 50 characters long")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; set;} = true;
    }
}
