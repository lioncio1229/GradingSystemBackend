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
                    return;

                if (dataContext.Database.EnsureCreated()) 
                    return;

                if(dataContext.Roles.Count() == 0)
                {
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
                }

                if(dataContext.Strands.Count() == 0)
                {
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

                    dataContext.Strands.AddRange(strands);
                }

                if (dataContext.YearLevels.Count() == 0)
                {
                    var yearLevel = new List<YearLevel>
                    {
                        new YearLevel { Name = "Grade 11" },
                        new YearLevel { Name = "Grade 12" }
                    };

                    dataContext.YearLevels.AddRange(yearLevel);
                }

                if(dataContext.Semesters.Count() == 0)
                {
                    var semester = new List<Semester>
                    {
                        new Semester { Name = "1"},
                        new Semester { Name = "2"}
                    };

                    dataContext.Semesters.AddRange(semester);
                }

                dataContext.SaveChanges();
            }
        }
    }
}
