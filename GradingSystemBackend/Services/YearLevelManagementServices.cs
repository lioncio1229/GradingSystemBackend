using AutoMapper;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Repositories;

namespace GradingSystemBackend.Services
{
    public class YearLevelManagementServices : IYearLevelManagementServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public YearLevelManagementServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<YearLevelResponse> GetAllYearLevel()
        {
            var yearLevelList =_unitOfWork.YearLevelRepository.GetAll();
            return _mapper.Map<IEnumerable<YearLevelResponse>>(yearLevelList);
        }
    }
}
