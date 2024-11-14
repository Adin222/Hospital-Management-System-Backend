using Hospital_Management_System.Static.ExceptionStatusMapper;
using Hospital_Management_System.Static.StatusCodeTypeMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, message: exception.Message);

            int statusCode = ExceptionStatusMapper.GetStatusCode(exception);
            string type = StatusCodeTypeMapper.GetType(statusCode);

            var details = new ProblemDetails
            {
                Detail = $"API Error: {exception.Message}",
                Instance = httpContext.Request.Path,
                Status = statusCode,
                Title = "API Error",
                Type = $"{type} ({statusCode})"
            };

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);

            return true;
        }

    }
}
