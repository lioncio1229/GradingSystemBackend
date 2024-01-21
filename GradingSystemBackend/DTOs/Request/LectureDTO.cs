using GradingSystemBackend.Model;

namespace GradingSystemBackend.DTOs.Request
{
    public class LectureDTO
    {
        public string LectureDate { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public Guid SubjectId1 { get; set; }
    }
}
