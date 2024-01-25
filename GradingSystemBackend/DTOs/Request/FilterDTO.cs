namespace GradingSystemBackend.DTOs.Request
{
    public class FilterDTO
    {
        public string Strand { get; set; } = string.Empty;
        public string YearLevel { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
    }
}
