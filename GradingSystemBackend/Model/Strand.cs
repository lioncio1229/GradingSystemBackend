using System.ComponentModel.DataAnnotations;

namespace GradingSystemBackend.Model
{
    public class Strand
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
