using AutoMapper;
using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Exceptions;
using GradingSystemBackend.Model;
using GradingSystemBackend.Repositories;

namespace GradingSystemBackend.Services
{
    public class SubjectManagementServices : ISubjectManagementServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubjectManagementServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DefaultResponse> AddSubject(SubjectDTO subject)
        {
            await _unitOfWork.SubjectRepository.AddAsync(_mapper.Map<Subject>(subject));

            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Message = "Subject Created",
                Success = true
            };
        }

        public DefaultResponse UpdateSubject(Guid id, SubjectDTO subjectDTO)
        {
            var subject = _mapper.Map<Subject>(subjectDTO);
            subject.Id = id;

            _unitOfWork.SubjectRepository.UpdateAsync(subject);
            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Message = "Subject Updated",
                Success = true
            };
        }
    }
}
