using GradingSystemBackend.DTOs.Response;

namespace GradingSystemBackend.Services
{
    public interface IYearLevelManagementServices
    {
        IEnumerable<YearLevelResponse> GetAllYearLevel();
    }
}
