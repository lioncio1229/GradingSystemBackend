using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;

namespace GradingSystemBackend.Services
{
    public interface IAuthServices
    {
        Task<AuthResponse> RegisterUser(UserRegistrationDTO user);
        Task<AuthResponse> LoginUser(UserLoginDTO credentials);
        Task<DefaultResponse> Logout();
    }
}
