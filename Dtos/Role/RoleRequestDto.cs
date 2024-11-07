using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Dtos.Role
{
    public class RoleRequestDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Key is required")]
        public string Key { get; set; } = null!;
    }
}
