using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;

namespace GradingSystemBackend.Services
{
    public interface ISubjectManagementServices
    {
        Task<DefaultResponse> AddSubject(NewSubjectDTO newSubject);
    }
}
