using System.ComponentModel.DataAnnotations;

namespace GradingSystemBackend.Model
{
    public class BlacklistedToken
    {
        [Key]
        public string Jti { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
