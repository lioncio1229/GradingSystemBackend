using GradingSystemBackend.Data;

namespace GradingSystemBackend.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _dataContext;
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IBlacklistedTokenRepository _blacklistRepository;
        private IStrandRepository _strandRepository;
        private ISubjectRepository _subjectRepository;
        private IStudentRepository _studentRepository;
        private IGradeRepository _gradeRepository;
        private ILectureRepository _lectureRepository;
        private IYearLevelRepository _yearLevelRepository;
        private bool disposed = false;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IYearLevelRepository YearLevelRepository
        {
            get
            {
                if (_yearLevelRepository == null)
                    _yearLevelRepository = new YearLevelRepository(_dataContext);
                return _yearLevelRepository;
            }
        }

        public ILectureRepository LectureRepository
        {
            get
            {
                if(_lectureRepository == null )
                    _lectureRepository = new LectureRepository(_dataContext);

                return _lectureRepository;
            }
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                    _studentRepository = new StudentRepository(_dataContext);
                return _studentRepository;
            }
        }

        public IGradeRepository GradeRepository
        {
            get
            {
                if (_gradeRepository == null)
                    _gradeRepository = new GradeRepository(_dataContext);
                return _gradeRepository;
            }
        }

        public ISubjectRepository SubjectRepository
        {
            get
            {
                if (_subjectRepository == null)
                    _subjectRepository = new SubjectRepository(_dataContext);

                return _subjectRepository;
            }
        }

        public IStrandRepository StrandRepository
        {
            get
            {
                if (_strandRepository == null)
                    _strandRepository = new StrandRepository(_dataContext);

                return _strandRepository;
            }
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
