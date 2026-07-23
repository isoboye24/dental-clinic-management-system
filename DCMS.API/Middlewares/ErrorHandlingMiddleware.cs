using DCMS.Application.Exceptions;
using DCMS.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace DCMS.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = HttpStatusCode.InternalServerError;
            object response;

            switch (exception)
            {
                case NotFoundException ex:
                    statusCode = HttpStatusCode.NotFound;
                    response = new
                    {
                        status = (int)statusCode,
                        message = ex.Message
                    };
                    break;

                case BusinessRuleException businessRuleException:
                    statusCode = HttpStatusCode.BadRequest;
                    response = JsonSerializer.Serialize(new
                    {
                        status = (int)statusCode,
                        message = businessRuleException.Message
                    });
                    break;

                case CustomValidationException ex:
                    statusCode = HttpStatusCode.BadRequest;
                    response = new
                    {
                        status = (int)statusCode,
                        errors = ex.ValidatorErrors
                    };
                    break;

                default:
                    response = new
                    {
                        status = (int)statusCode,
                        message = "An unexpected error occurred."
                    };
                    break;
            }

            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }

    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
