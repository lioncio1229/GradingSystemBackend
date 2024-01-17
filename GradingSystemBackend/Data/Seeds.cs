using GradingSystemBackend.Model;

namespace GradingSystemBackend.Data
{
    public static class Seeds
    {
        public static void Generate(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetService<DataContext>();

                if (dataContext == null)
                {
                    return;
                }

                if (!dataContext.Database.EnsureCreated())
                {
                    return;
                }

                var roles = new List<Role>
                {
                    new Role
                    {
                        Name = "admin",
                    },
                    new Role
                    {
                        Name = "User"
                    }
                };

                dataContext.Roles.AddRange(roles);
                dataContext.SaveChanges();
            }
        }
    }
}
