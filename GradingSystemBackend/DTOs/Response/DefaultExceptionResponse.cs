namespace GradingSystemBackend.DTOs.Response
{
    public class DefaultExceptionResponse
    {
        public string Message { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }
        public object Data { get; set; }

        public DefaultExceptionResponse()
        {
            this.Errors = new Dictionary<string, string[]>();
        }
    }
}
