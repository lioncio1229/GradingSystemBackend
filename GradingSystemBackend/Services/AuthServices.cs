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
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly JWTSettings _jwtSettings;

        public AuthServices(IUnitOfWork unityOfWork, IOptions<JWTSettings> options, IHttpContextAccessor contextAccessor)
        {
            _unityOfWork = unityOfWork;
            _jwtSettings = options.Value;
            _contextAccessor = contextAccessor;
        }

        public async Task<AuthResponse> RegisterUser(UserRegistrationDTO credentials)
        {
            var roles = _unityOfWork.RoleRepository.GetAll().ToList();

            await _unityOfWork.UserRepository.AddAsync(new Model.User
            {
                Email = credentials.Email,
                UserName = credentials.Username,
                Password = credentials.Password,
                FirstName = credentials.FirstName,
                LastName = credentials.LastName,
                Roles = new List<Role>
                {
                    roles[0]
                }
            });
            _unityOfWork.SaveChanges();

            var token = GenerateToken(credentials.Email, new List<Role> { roles[0] });

            return new AuthResponse
            {
                Token = token
            };
        }

        public async Task<AuthResponse> LoginUser(UserLoginDTO credentials)
        {
            var user = await _unityOfWork.UserRepository.Get(o => o.UserName == credentials.UserName && o.Password == credentials.Password, o => o.Roles);

            if(user == null)
                throw new UnauthorizedException("Unauthorize");

            var token = GenerateToken(user.Email, user.Roles.ToList());
            return new AuthResponse { Token = token };
        }

        public async Task<DefaultResponse> Logout()
        {
            var context = _contextAccessor.HttpContext;

            if (context != null)
            {
                var identity = context.User.Identity as ClaimsIdentity;

                if (identity != null)
                {
                    var jtiClaim = identity.FindFirst(JwtRegisteredClaimNames.Jti);

                    if (jtiClaim != null)
                    {
                        var revokedToken = jtiClaim.Value;
                        await BlacklistToken(revokedToken);

                        return new DefaultResponse
                        {
                            Message = "Successfully Logged Out",
                            Success = true
                        };
                    }
                }
            }

            throw new UnauthorizedException("Unauthorize");
        }

        public async Task BlacklistToken(string jti)
        {
            var token = await _unityOfWork.BlacklistedTokenRepository.Get(o => o.Jti == jti);
            if(token == null)
            {
                await _unityOfWork.BlacklistedTokenRepository.AddAsync(new BlacklistedToken
                {
                    Jti = jti,
                    Date = DateTime.Now.Date,
                });
                _unityOfWork.SaveChanges();
            }
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
