using GradingSystemBackend.Model;
using Microsoft.EntityFrameworkCore;

namespace GradingSystemBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>().HasKey(o => new { o.UserId, o.Strand });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BlacklistedToken> BlacklistedTokens { get; set; }
        public DbSet<Strand> Strands { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
    }
}
