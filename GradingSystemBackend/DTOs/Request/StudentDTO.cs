using GradingSystemBackend.Model;

namespace GradingSystemBackend.DTOs.Request
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Sufix { get; set; }
        public string Birthdate { get; set; }
        public string Nationality { get; set; }
        public string MobileNumber { get; set; }
        public string FacebookUrl { get; set; }
        public string LRN { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public string StudentType { get; set; }
        public string StrandCode { get; set; }
        public string YearLevelKey { get; set; }
        public string SemesterKey { get; set; }
    }
}
