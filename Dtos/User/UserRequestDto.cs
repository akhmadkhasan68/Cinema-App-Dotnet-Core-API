using System.ComponentModel.DataAnnotations;
using CinemaApp.Utils.Constans;

namespace CinemaApp.Dtos.User
{
    public class UserRequestDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email must be a valid email address")]
        public string Email { get; set; } = null!;
        
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        [MaxLength(20, ErrorMessage = "Password must be at most 20 characters")]
        [RegularExpression(Regex.Password, ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, and one number")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [Compare("Password", ErrorMessage = "Password and ConfirmPassword must match")]
        public string ConfirmPassword { get; set; } = null!;
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;
        
        [Required(ErrorMessage = "RoleId is required")]
        public int RoleId { get; set; }
    }
}
