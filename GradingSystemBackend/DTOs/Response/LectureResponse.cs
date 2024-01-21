using GradingSystemBackend.Model;

namespace GradingSystemBackend.DTOs.Response
{
    public class LectureResponse
    {
        public Guid Id { get; set; }
        public string LectureDate { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
        public SubjectResponse Subject { get; set; }
    }
}
