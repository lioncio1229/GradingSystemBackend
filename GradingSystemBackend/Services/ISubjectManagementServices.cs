using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;

namespace GradingSystemBackend.Services
{
    public interface ISubjectManagementServices
    {
        Task<DefaultResponse> AddSubject(SubjectDTO newSubject);
        DefaultResponse UpdateSubject(Guid id, SubjectDTO subject);
    }
}
