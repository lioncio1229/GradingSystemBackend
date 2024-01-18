namespace GradingSystemBackend.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IBlacklistedTokenRepository BlacklistedTokenRepository { get; }
        IStrandRepository StrandRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        void SaveChanges();
    }
}
