using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
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
        public async Task<ActionResult<AuthResponse>> Register(UserRegistrationDTO user)
        {
            var response = await _authServices.RegisterUser(user);
            return Ok(response);
        }
    }
}
