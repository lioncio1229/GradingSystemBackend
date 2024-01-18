namespace GradingSystemBackend.Model
{
    public class Faculty
    {
        public Guid UserId { get; set; }
        public Guid StrandId { get; set; }
        public User User { get; set; }
        public Strand Strand { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
