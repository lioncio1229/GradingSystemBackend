﻿using GradingSystemBackend.Model;

namespace GradingSystemBackend.DTOs.Response
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<RoleResponse> Roles { get; set; }
    }
}
