using GradingSystemBackend.Model;

namespace GradingSystemBackend.DTOs.Request
{
    public class NewSubjectDTO
    {
        public string Name { get; set; }
        public string Room { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public Guid FacultyId { get; set; }
        public string Strand { get; set; }
        public string YearLevel { get; set; }
        public string Semester { get; set; }
    }
}
