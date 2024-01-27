using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;

namespace GradingSystemBackend.Services
{
    public interface IGradeManagementServices
    {
        Task<DefaultResponse> UpdateGrades(Guid id, GradesUpdateDTO gradeUpdateDTO);
        IEnumerable<StudentGradeResponse> GetStudentGrades(Guid subjectId);
    }
}
