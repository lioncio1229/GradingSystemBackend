using GradingSystemBackend.Data;
using GradingSystemBackend.Model;

namespace GradingSystemBackend.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext context) : base(context)
        {
        }
    }
}
