namespace GradingSystemBackend.Model
{
    public class Grade
    {
        public Guid Id { get; set; }
        public int Q1 { get; set; }
        public int Q2 { get; set; }
        public int Q3 { get; set; }
        public int Q4 { get; set; }
        public string Remarks {  get; set; }
        public Subject Subject { get; set; }
        public Student Student { get; set; }
    }
}
