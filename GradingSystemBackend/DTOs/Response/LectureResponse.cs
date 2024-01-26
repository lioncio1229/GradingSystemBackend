using GradingSystemBackend.Model;

namespace GradingSystemBackend.DTOs.Response
{
    public class LectureResponse
    {
        public Guid Id { get; set; }
        public string LectureDate { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public SubjectResponse Subject { get; set; }
    }
}
