using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;
using GradingSystemBackend.Model;
using GradingSystemBackend.Repositories;

namespace GradingSystemBackend.Services
{
    public class SubjectManagementServices : ISubjectManagementServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubjectManagementServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DefaultResponse> AddSubject(NewSubjectDTO newSubject)
        {
            await _unitOfWork.SubjectRepository.AddAsync(new Subject
            {
                Code = newSubject.Code,
                Name = newSubject.Name,
                Room = newSubject.Room,
                Type = newSubject.Type,
                UserId = newSubject.FacultyId,
                SemesterId = newSubject.SemesterId,
                StrandId = newSubject.StrandId,
                YearLevelId = newSubject.YearLevelId,
            });

            _unitOfWork.SaveChanges();

            return new DefaultResponse
            {
                Message = "Subject Created",
                Success = true
            };
        }
    }
}
