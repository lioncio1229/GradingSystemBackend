using GradingSystemBackend.DTOs.Response;

namespace GradingSystemBackend.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(DefaultExceptionResponse exceptionResponse) : base()
        {
            this.Data.Add("exceptionData", exceptionResponse);
        }

        public BadRequestException(string field, string errorMessage) : base()
        {
            var exceptionResponse = new DefaultExceptionResponse
            {
                Message = errorMessage,
                Errors = new Dictionary<string, string[]>
                {
                    [field] = new string[] { errorMessage }
                }
            };

            this.Data.Add("exceptionData", exceptionResponse);
        }
    }
}
