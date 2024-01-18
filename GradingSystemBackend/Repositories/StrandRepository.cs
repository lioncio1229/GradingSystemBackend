using GradingSystemBackend.Data;
using GradingSystemBackend.Model;

namespace GradingSystemBackend.Repositories
{
    public class StrandRepository : Repository<Strand>, IStrandRepository
    {
        public StrandRepository(DataContext context) : base(context)
        {
        }
    }
}
