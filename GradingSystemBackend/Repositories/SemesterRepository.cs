using GradingSystemBackend.Data;
using GradingSystemBackend.Model;

namespace GradingSystemBackend.Repositories
{
    public class SemesterRepository : Repository<Semester>, ISemesterRepository
    {
        public SemesterRepository(DataContext context) : base(context)
        {
        }
    }
}
