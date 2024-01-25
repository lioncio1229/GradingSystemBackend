using GradingSystemBackend.Model;

namespace GradingSystemBackend.DTOs.Response
{
    public class SubjectResponse
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public UserResponse Faculty { get; set; }
        public StrandResponse Strand { get; set; }
        public YearLevelResponse YearLevel { get; set; }
        public SemesterResponse Semester { get; set; }
    }
}
