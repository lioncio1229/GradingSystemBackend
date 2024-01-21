using GradingSystemBackend.Model;

namespace GradingSystemBackend.DTOs.Response
{
    public class SubjectResponse
    {
        public string Name { get; set; }
        public string Room { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public User Faculty { get; set; }
        public Strand Strand { get; set; }
        public YearLevel YearLevel { get; set; }
        public Semester Semester { get; set; }
    }
}
