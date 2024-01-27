using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;

namespace GradingSystemBackend.Services
{
    public interface ISubjectManagementServices
    {
        Task<DefaultResponse> AddSubject(SubjectDTO newSubject);
        DefaultResponse UpdateSubject(Guid id, SubjectDTO subject);
        IEnumerable<SubjectResponse> GetSubjects();
        IEnumerable<SubjectResponse> GetSubjects(FilterDTO filterDTO);
        IEnumerable<SubjectResponse> GetSubjects(Guid userId);
        Task<SubjectResponse> GetSubject(Guid id);
        Task<DefaultResponse> DeleteSubject(Guid id);
    }
}
