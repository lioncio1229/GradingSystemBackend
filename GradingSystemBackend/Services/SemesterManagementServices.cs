using AutoMapper;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Repositories;

namespace GradingSystemBackend.Services
{
    public class SemesterManagementServices : ISemesterManagementServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SemesterManagementServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<SemesterResponse> GetAllSemester() 
        { 
            var semesters =_unitOfWork.SemesterRepository.GetAll();
            return _mapper.Map<IEnumerable<SemesterResponse>>(semesters);
        }
    }
}
