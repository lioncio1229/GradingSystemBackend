using GradingSystemBackend.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace GradingSystemBackend.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            string message = exception.Message;
            object exceptionData = null;

            if (exception.Data.Count > 0)
                exceptionData = exception.Data["exceptionData"];

            switch (exception.GetType().Name)
            {
                case nameof(BadRequestException):
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case nameof(ForbiddenException):
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    break;

                case nameof(UnauthorizedException):
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case nameof(NotFoundException):
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    message = "Unexpected error.";
#if DEBUG
                    message = exception.ToString();
#endif
                    break;
            }

            if (exceptionData != null)
            {
                return context.Response.WriteAsync(JsonConvert.SerializeObject(exceptionData, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() }
                }));
            }
            else
                return context.Response.WriteAsync(JsonConvert.SerializeObject(new { message }));

        }
    }
}
