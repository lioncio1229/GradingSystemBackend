using AutoMapper;
using GradingSystemBackend.Configurations;
using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Exceptions;
using GradingSystemBackend.Model;
using GradingSystemBackend.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GradingSystemBackend.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IStudentServices _studentServices;
        private readonly JWTSettings _jwtSettings;

        public AuthServices(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IOptions<JWTSettings> options, 
            IHttpContextAccessor contextAccessor, 
            IStudentServices studentServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtSettings = options.Value;
            _contextAccessor = contextAccessor;
            _studentServices = studentServices;

        }

        public async Task<AuthResponse> RegisterUser(UserRegistrationDTO credentials)
        {
            var roles = _unitOfWork.RoleRepository.GetAll().ToList();

            var user = await _unitOfWork.UserRepository.AddAsync(new Model.User
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
            _unitOfWork.SaveChanges();

            var userData = _mapper.Map<UserData>(user);
            var token = GenerateToken(userData, new List<Role> { roles[0] });

            return new AuthResponse
            {
                Token = token
            };
        }

        public async Task<AuthResponse> LoginUser(UserLoginDTO credentials)
        {
            var user = await _unitOfWork.UserRepository.Get(o => o.UserName == credentials.UserName && o.Password == credentials.Password, o => o.Roles);

            if (user == null)
                throw new UnauthorizedException("Unauthorize");

            var userData = _mapper.Map<UserData>(user);
            var token = GenerateToken(userData, user.Roles.ToList());
            return new AuthResponse { Token = token };
        }

        public async Task<AuthResponse> RegisterStudent(StudentDTO studentDTO)
        {
            var response = await _studentServices.AddStudent(studentDTO);

            var studentRole = await _unitOfWork.RoleRepository.Get(o => o.Name == "student");
            var userData = new UserData
            {
                Email = studentDTO.Email,
                UserName = "",
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName,
            };
            var token = GenerateToken(userData, new List<Role> { studentRole });
            return new AuthResponse { Token = token };
        }

        public async Task<AuthResponse> LoginStudent(StudentLoginDTO studentLoginDTO)
        {
            var student = await _unitOfWork.StudentRepository.Get(o => o.LRN == studentLoginDTO.LRN);
            if (student == null)
                throw new NotFoundException("Student LRN not found");

            var userData = new UserData
            {
                Email = student.Email,
                UserName = "",
                FirstName = student.FirstName,
                LastName = student.LastName,
            };
            var studentRole = await _unitOfWork.RoleRepository.Get(o => o.Name == "student");
            var token = GenerateToken(userData, new List<Role> { studentRole });

            return new AuthResponse {  Token= token };
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
            var token = await _unitOfWork.BlacklistedTokenRepository.Get(o => o.Jti == jti);
            if(token == null)
            {
                await _unitOfWork.BlacklistedTokenRepository.AddAsync(new BlacklistedToken
                {
                    Jti = jti,
                    Date = DateTime.Now.Date,
                });
                _unitOfWork.SaveChanges();
            }
        }

        public string GenerateToken(UserData userData, List<Role> roles)
        {
            string jti = Guid.NewGuid().ToString();
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey);

            var claims = new List<Claim>
            {
                new ("userData", JsonConvert.SerializeObject(userData, Formatting.Indented)),
                new (JwtRegisteredClaimNames.Jti, jti)
            };

            claims.AddRange(roles.Select(o => new Claim(ClaimTypes.Role, o.Name)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.Now.AddMinutes(100),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string finalToken = tokenHandler.WriteToken(token);

            return finalToken;
        }
    }
}
