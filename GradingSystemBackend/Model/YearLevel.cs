using System.ComponentModel.DataAnnotations;

namespace GradingSystemBackend.Model
{
    public class YearLevel
    {
        [Key]
        public string Key { get; set; }
        public string Name { get; set; }
        public ICollection<Subject>? Subjects { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}
