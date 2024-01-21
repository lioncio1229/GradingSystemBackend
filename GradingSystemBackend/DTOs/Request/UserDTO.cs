
namespace GradingSystemBackend.DTOs.Request
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string>? Roles { get; set; }
    }
}
