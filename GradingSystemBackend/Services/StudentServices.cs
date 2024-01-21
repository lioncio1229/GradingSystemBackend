using GradingSystemBackend.Repositories;

namespace GradingSystemBackend.Services
{
    public class StudentServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


    }
}
