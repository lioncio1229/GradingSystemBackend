using GradingSystemBackend.Model;
using Microsoft.EntityFrameworkCore;

namespace GradingSystemBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BlacklistedToken> BlacklistedTokens { get; set; }
        public DbSet<Strand> Strands { get; set; }
    }
}
