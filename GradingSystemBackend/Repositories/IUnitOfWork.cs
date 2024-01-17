namespace GradingSystemBackend.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        void SaveChanges();
    }
}
