using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Exceptions;
using GradingSystemBackend.Model;

namespace GradingSystemBackend.Services
{
    public interface IAuthServices
    {
        Task<AuthResponse> RegisterUser(UserRegistrationDTO user);

        Task<AuthResponse> LoginUser(UserLoginDTO credentials);

        Task<AuthResponse> RegisterStudent(StudentDTO studentDTO);

        Task<AuthResponse> LoginStudent(StudentLoginDTO studentLoginDTO);

        Task<DefaultResponse> Logout();
    }
}
