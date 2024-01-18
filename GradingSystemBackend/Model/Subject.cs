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
        public Strand Strand { get; set; }
        public Guid StrandId { get; set; }
        public YearLevel YearLevel { get; set; }
        public Guid YearLevelId { get; set; }
        public Semester Semester { get; set; }
        public Guid SemesterId { get; set; }
    }
}
