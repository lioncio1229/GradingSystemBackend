using GradingSystemBackend.DTOs.Response;

namespace GradingSystemBackend.Services
{
    public interface ISemesterManagementServices
    {
        IEnumerable<SemesterResponse> GetAllSemester();
    }
}
