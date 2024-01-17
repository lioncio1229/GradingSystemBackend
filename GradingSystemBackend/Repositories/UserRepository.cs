using GradingSystemBackend.Data;
using GradingSystemBackend.Model;

namespace GradingSystemBackend.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}
