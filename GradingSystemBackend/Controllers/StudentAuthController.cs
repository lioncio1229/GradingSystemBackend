using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradingSystemBackend.Controllers
{
    [ApiController]
    [Route("api/v1/studentauth")]
    public class StudentAuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        public StudentAuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("register")]
        [ProducesResponseType<AuthResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterStudent(StudentDTO studentDTO)
        {
            var response = await _authServices.RegisterStudent(studentDTO);
            return Ok(response);
        }

        [HttpPost("login")]
        [ProducesResponseType<AuthResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LoginStudent(StudentLoginDTO studentLoginDTO)
        {
            var response = await _authServices.LoginStudent(studentLoginDTO);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("logout")]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Logout()
        {
            var response = await _authServices.Logout();
            return Ok(response);
        }
    }
}
