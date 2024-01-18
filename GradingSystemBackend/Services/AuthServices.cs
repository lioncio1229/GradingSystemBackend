using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Exceptions;
using GradingSystemBackend.Model;
using GradingSystemBackend.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GradingSystemBackend.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IUnitOfWork _unityOfWork;
        private readonly JWTSettings _jwtSettings;

        public AuthServices(IUnitOfWork unityOfWork, IOptions<JWTSettings> options)
        {
            _unityOfWork = unityOfWork;
            _jwtSettings = options.Value;
        }

        public async Task<AuthResponse> RegisterUser(UserRegistrationDTO user)
        {
            var roles = _unityOfWork.RoleRepository.GetAll().ToList();

            await _unityOfWork.UserRepository.AddAsync(new Model.User
            {
                Email = user.Email,
                Password = user.Password,
                Roles = new List<Role>
                {
                    roles[0]
                }
            });
            _unityOfWork.SaveChanges();

            var token = GenerateToken(user.Email, new List<Role> { roles[0] });

            return new AuthResponse
            {
                Token = token
            };
        }

        public string GenerateToken(string email, List<Role> roles)
        {
            string jti = Guid.NewGuid().ToString();
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey);

            var claims = new List<Claim>
            {
                new (ClaimTypes.Name, email),
                new (JwtRegisteredClaimNames.Jti, jti)
            };

            claims.AddRange(roles.Select(o => new Claim(ClaimTypes.Role, o.Name)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.Now.AddMinutes(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string finalToken = tokenHandler.WriteToken(token);

            return finalToken;
        }

    }
}
