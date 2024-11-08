using CinemaApp.Infrastructures.Responses;
using Microsoft.AspNetCore.Diagnostics;

namespace CinemaApp.Infrastructures.Exceptions
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger = logger;

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext, 
            Exception exception, 
            CancellationToken cancellationToken
        )
        {
            _logger.LogError(exception, $"Exception occurred: {exception.Message}");

            var statusCode = exception switch
            {
                DataNotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status400BadRequest,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            var title = exception switch
            {
                DataNotFoundException => "Data not found",
                ValidationException => "Validation error",
                UnauthorizedAccessException => "Unauthorized access",
                _ => "An error occurred"
            };

            var errors = exception switch
            {
                ValidationException validationException => validationException.Errors,
                _ => [exception.Message]
            };

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsJsonAsync(new ApiResponse {
                Status = statusCode,
                Message = title,
                Errors = errors
            }, cancellationToken);

            return true;
        }
    }
}
