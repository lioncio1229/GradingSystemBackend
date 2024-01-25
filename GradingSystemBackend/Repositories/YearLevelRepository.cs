using GradingSystemBackend.Data;
using GradingSystemBackend.Model;

namespace GradingSystemBackend.Repositories
{
    public class YearLevelRepository : Repository<YearLevel>, IYearLevelRepository
    {
        public YearLevelRepository(DataContext context) : base(context)
        {
        }
    }
}
