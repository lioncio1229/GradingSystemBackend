using System.ComponentModel.DataAnnotations;

namespace GradingSystemBackend.Model
{
    public class Strand
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
        public ICollection<Subject?> Subjects { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}
