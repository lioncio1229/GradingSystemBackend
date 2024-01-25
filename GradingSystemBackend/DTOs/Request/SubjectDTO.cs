using Newtonsoft.Json;

namespace GradingSystemBackend.DTOs.Request
{
    public class SubjectDTO
    {
        public string Name { get; set; }
        public string Room { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }

        [JsonProperty("FacultyId")]
        public Guid UserId { get; set; }
        public string StrandCode { get; set; }
        public string YearLevelKey { get; set; }
        public string SemesterKey { get; set; }
    }
}
