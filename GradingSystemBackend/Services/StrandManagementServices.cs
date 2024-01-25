using AutoMapper;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Repositories;

namespace GradingSystemBackend.Services
{
    public class StrandManagementServices : IStrandManagementServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public StrandManagementServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<StrandResponse> GetAllStrands()
        {
            var strands = _unitOfWork.StrandRepository.GetAll().ToList();
            return _mapper.Map<IEnumerable<StrandResponse>>(strands);
        }
    }
}
