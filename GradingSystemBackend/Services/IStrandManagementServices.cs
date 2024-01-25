using GradingSystemBackend.DTOs.Response;

namespace GradingSystemBackend.Services
{
    public interface IStrandManagementServices
    {
        IEnumerable<StrandResponse> GetAllStrands();
    }
}
