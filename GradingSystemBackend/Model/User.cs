﻿namespace GradingSystemBackend.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Strand> Strands { get; set; }
    }
}
