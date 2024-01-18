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

                if(dataContext.Roles.Count() > 0)
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

                var strands = new List<Strand>
                {
                    new Strand
                    {
                        Name = "ABM",
                        Description = "Accountancy, Business, and Management",
                    },
                    new Strand
                    {
                        Name = "HUMMS",
                        Description = "Humanities and Social Sciences"
                    },
                    new Strand
                    {
                        Name = "GAS",
                        Description = "General Academic Strand"
                    },
                    new Strand
                    {
                        Name = "ICT",
                        Description = "Information and Communication Technology"
                    },
                    new Strand
                    {
                        Name = "H.E",
                        Description = "Home Economics"
                    }
                };

                dataContext.Roles.AddRange(roles);
                dataContext.Strands.AddRange(strands);

                dataContext.SaveChanges();
            }
        }
    }
}
