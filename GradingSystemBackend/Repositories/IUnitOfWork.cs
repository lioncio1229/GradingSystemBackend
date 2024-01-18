namespace GradingSystemBackend.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IBlacklistedTokenRepository BlacklistedTokenRepository { get; }
        void SaveChanges();
    }
}
