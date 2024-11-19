namespace MiddlewareApp.middlewares;

class LoggerMiddleware
{
    private readonly ILogger<LoggerMiddleware> _logger;
    private readonly RequestDelegate _next;
    public LoggerMiddleware(ILogger<LoggerMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context){
        Console.WriteLine("Logging boshlandi");
        foreach (var header in context.Request.Headers)
        {
            _logger.LogInformation($"{header.Key}: {header.Value}");
        }
        await _next(context);
        Console.WriteLine("Logging tugadi");
    }
}