using GradingSystemBackend.Model;
using System.ComponentModel.DataAnnotations;

namespace GradingSystemBackend.DTOs.Request
{
    public class UserRegistrationDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
    }
}
