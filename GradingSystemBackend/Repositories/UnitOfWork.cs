﻿using GradingSystemBackend.Data;

namespace GradingSystemBackend.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _dataContext;
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IBlacklistedTokenRepository _blacklistRepository;
        private bool disposed = false;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IBlacklistedTokenRepository BlacklistedTokenRepository
        {
            get
            {
                if (_blacklistRepository == null)
                    _blacklistRepository = new BlacklistedTokenRepository(_dataContext);

                return _blacklistRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if( _userRepository == null)
                    _userRepository = new UserRepository(_dataContext);

                return _userRepository;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                if(_roleRepository == null)
                    _roleRepository = new RoleRepository(_dataContext);
                return _roleRepository;
            }
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
