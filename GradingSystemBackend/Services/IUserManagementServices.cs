using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;

namespace GradingSystemBackend.Services
{
    public interface IUserManagementServices
    {
        Task<DefaultResponse> AddUser(AddUserDTO addUserDTO);

        IEnumerable<UserResponse> GetAllUser();

        Task<UserResponse> GetUser(Guid id);

        Task<DefaultResponse> UpdateUser(Guid id, UserDTO userDTO);

        Task<DefaultResponse> DeleteUser(Guid id);
    }
}
