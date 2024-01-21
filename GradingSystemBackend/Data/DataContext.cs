using GradingSystemBackend.Model;
using Microsoft.EntityFrameworkCore;

namespace GradingSystemBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>().HasKey(o => new { o.SubjectId, o.StudentId });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BlacklistedToken> BlacklistedTokens { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Strand> Strands { get; set; }
        public DbSet<YearLevel> YearLevels { get; set; }
        public DbSet<Semester> Semesters { get; set; }
    }
}
