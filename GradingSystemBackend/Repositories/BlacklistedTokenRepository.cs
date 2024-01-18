using GradingSystemBackend.Data;
using GradingSystemBackend.Model;

namespace GradingSystemBackend.Repositories
{
    public class BlacklistedTokenRepository : Repository<BlacklistedToken>, IBlacklistedTokenRepository
    {
        public BlacklistedTokenRepository(DataContext context) : base(context)
        {
        }
    }
}
