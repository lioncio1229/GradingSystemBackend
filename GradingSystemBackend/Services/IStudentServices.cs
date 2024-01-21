using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;

namespace GradingSystemBackend.Services
{
    public interface IStudentServices
    {
        Task<DefaultResponse> AddStudent(StudentDTO studentDTO);

        IEnumerable<StudentResponse> GetStudents();

        Task<StudentResponse> GetStudent(Guid id);

        Task<DefaultResponse> UpdateStudent(Guid id, StudentDTO studentDTO);

        Task<DefaultResponse> DeleteStudent(Guid id);
    }
}
