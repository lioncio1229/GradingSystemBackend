using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Exceptions;
using GradingSystemBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace GradingSystemBackend.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("register")]
        [ProducesResponseType<AuthResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register(UserRegistrationDTO user)
        {
            var response = await _authServices.RegisterUser(user);
            return Ok(response);
        }

        [HttpPost("login")]
        [ProducesResponseType<AuthResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<DefaultExceptionResponse>(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(UserLoginDTO user)
        {
            var response = await _authServices.LoginUser(user);
            return Ok(response);
        }
    }
}
