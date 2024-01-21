namespace GradingSystemBackend.DTOs.Request
{
    public class GradesUpdateDTO
    {
        public int Q1 { get; set; }
        public int Q2 { get; set; }
        public int Q3 { get; set; }
        public int Q4 { get; set; }
        public int Average { get; set; }
        public string Remarks { get; set; }
    }
}
