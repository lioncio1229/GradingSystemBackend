using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace GradingSystemBackend.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserManagementServices _userManagementServices;

        public UserController(IUserManagementServices userManagementServices)
        {
            _userManagementServices = userManagementServices;
        }

        [HttpGet]
        [ProducesResponseType<IEnumerable<UserResponse>>(StatusCodes.Status200OK)]
        public IActionResult GetAllUser()
        {
            return Ok(_userManagementServices.GetAllUser());
        }

        [HttpGet("{id}")]
        [ProducesResponseType<UserResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var response = await _userManagementServices.GetUser(id);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddUser(AddUserDTO addUserDTO)
        {
            var response = await _userManagementServices.AddUser(addUserDTO);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(Guid id, UserDTO userDTO)
        {
            var response = await _userManagementServices.UpdateUser(id, userDTO);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var response = await _userManagementServices.DeleteUser(id);
            return Ok(response);
        }
    }
}
