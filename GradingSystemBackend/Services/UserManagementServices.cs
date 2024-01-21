using AutoMapper;
using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Exceptions;
using GradingSystemBackend.Model;
using GradingSystemBackend.Repositories;

namespace GradingSystemBackend.Services
{
    public class UserManagementServices : IUserManagementServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserManagementServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.UserRepository;
            _mapper = mapper;
        }

        public async Task<DefaultResponse> AddUser(AddUserDTO addUserDTO)
        {
            var roles = await _unitOfWork.RoleRepository
                .GetAllAsync(o => addUserDTO.Roles != null ? addUserDTO.Roles.Contains(o.Name) : false);

            var user = new User
            {
                Email = addUserDTO.Email,
                UserName = addUserDTO.Username,
                FirstName = addUserDTO.FirstName,
                LastName = addUserDTO.LastName,
                Password = addUserDTO.Password,
                Roles = roles
            };

            await _userRepository.AddAsync(_mapper.Map<User>(user));
            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Message = "User added",
                Success = true,
                Data = _mapper.Map<UserResponse>(user)
            };
        }

        public IEnumerable<UserResponse> GetAllUser()
        {
            var users = _userRepository.GetAll(o => o.Roles);
            return _mapper.Map<IEnumerable<UserResponse>>(users);
        }

        public async Task<UserResponse> GetUser(Guid id)
        {
            var users = await _userRepository.Get(o => o.Id == id, o => o.Roles);
            return _mapper.Map<UserResponse>(users);
        }

        public async Task<DefaultResponse> UpdateUser(Guid id, UserDTO userDTO)
        {
            var user = await _userRepository.Get(o => o.Id == id);
            if (user == null)
                throw new NotFoundException("User not found");


            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;

            if(userDTO.Roles?.Count() > 0)
            {
                var roles = await _unitOfWork.RoleRepository.GetAllAsync(o => userDTO.Roles.Contains(o.Name));
                user.Roles = roles;
            }

            _userRepository.UpdateAsync(user);
            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Message = "User udpated",
                Success = true
            };
        }

        public async Task<DefaultResponse> DeleteUser(Guid id)
        {
            var user = await _userRepository.Get(o => o.Id == id);
            if (user == null)
                throw new NotFoundException("User not found");

            _userRepository.Delete(user);
            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Message = "User deleted",
                Success = true
            };
        }
    }
}
