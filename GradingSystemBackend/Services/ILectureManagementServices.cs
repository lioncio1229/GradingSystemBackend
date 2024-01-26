using GradingSystemBackend.DTOs.Request;
using GradingSystemBackend.DTOs.Response;

namespace GradingSystemBackend.Services
{
    public interface ILectureManagementServices
    {
        Task<DefaultResponse> AddLecture(LectureDTO lectureDTO);

        IEnumerable<LectureResponse> GetAllLecture();

        IEnumerable<LectureResponse> GetAllLecture(FilterDTO filterDTO);

        Task<LectureResponse> GetLecture(Guid id);

        Task<DefaultResponse> UpdateLecture(Guid id, LectureDTO lectureDTO);

        Task<DefaultResponse> DeleteLecture(Guid id);
    }
}
