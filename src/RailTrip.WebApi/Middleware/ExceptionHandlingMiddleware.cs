using RailTrip.Domain.Exceptions.Base;
using System.Text.Json;
using ValidationException = RailTrip.Application.Exceptions.ValidationException;

namespace RailTrip.WebApi.Middleware
{
    internal sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = ex switch
            {
                BadRequestException or ValidationException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            var errors = Array.Empty<ApiError>();

            if (ex is ValidationException validationException)
            {
                errors = validationException.Errors
                    .SelectMany(
                        kvp => kvp.Value,
                        (kvp, value) => new ApiError(kvp.Key, value))
                    .ToArray();
            }

            var response = new
            {
                status = httpContext.Response.StatusCode,
                message = ex.Message,
                errors
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private record ApiError(string PropertyName, string ErrorMessage);
    }
}
