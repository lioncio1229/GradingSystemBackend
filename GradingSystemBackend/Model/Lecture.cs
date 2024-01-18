namespace GradingSystemBackend.Model
{
    public class Lecture
    {
        public Guid Id { get; set; }
        public string LectureDate { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public Subject Subject { get; set; }
    }
}
