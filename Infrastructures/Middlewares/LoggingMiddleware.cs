
namespace CinemaApp.Infrastructures.Middlewares
{
    public class LoggingMiddleware(ILogger<LoggingMiddleware> logger) : IMiddleware
    {
        private readonly ILogger<LoggingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            LogRequest(context);

            await next(context);

            LogResponse(context);
        }

        private void LogRequest(HttpContext context)
        {
            var request = context.Request;
            _logger.LogInformation(
                "Incoming request: {Method} {Scheme} {Host} {Path} {QueryString}",
                request.Method,
                request.Scheme,
                request.Host,
                request.Path,
                request.QueryString
            );
        }

        private void LogResponse(HttpContext context)
        {
            var response = context.Response;
            _logger.LogInformation(
                "Outgoing response: {StatusCode}",
                response.StatusCode
            );
        }
    }
}
