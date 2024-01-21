namespace GradingSystemBackend.Model
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public User Faculty { get; set; }
        public Guid UserId { get; set; }
        public Strand? Strand { get; set; }
        public string? StrandCode { get; set; }
        public YearLevel? YearLevel { get; set; }
        public string? YearLevelKey { get; set; }
        public Semester? Semester { get; set; }
        public string? SemesterKey { get; set; }
    }
}
