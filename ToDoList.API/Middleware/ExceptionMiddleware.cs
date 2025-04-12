using System.Text.Json;

namespace ToDoList.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unhandled exception occurred. TraceId: {TraceId}", context.TraceIdentifier);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var (statusCode, message) = exception switch
            {
                NullReferenceException => (StatusCodes.Status404NotFound, "Resource not found."),
                ArgumentException => (StatusCodes.Status400BadRequest, "Invalid request parameters."),
                KeyNotFoundException => (StatusCodes.Status404NotFound, "Requested resource not found."),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred. Please try again later.")
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var result = JsonSerializer.Serialize(new
            {
                type = $"https://tools.ietf.org/html/rfc9110#section-15.{statusCode switch { 400 => "5.1", 404 => "5.5", 500 => "6.1", _ => "5.1" }}",
                title = message,
                status = statusCode,
                traceId = context.TraceIdentifier
            });
            return context.Response.WriteAsync(result);
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}