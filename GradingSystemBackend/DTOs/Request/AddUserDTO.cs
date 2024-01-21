using System.ComponentModel.DataAnnotations;

namespace GradingSystemBackend.DTOs.Request
{
    public class AddUserDTO
    {
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string>? Roles { get; set; }
    }
}
