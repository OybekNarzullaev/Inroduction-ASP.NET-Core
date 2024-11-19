namespace MiddlewareApp.middlewares;

class RequestTimingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestTimingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync (HttpContext  context) {
        var stopwatch = new System.Diagnostics.Stopwatch();

        stopwatch.Start();
        await Task.Delay(0);
        await _next(context);
        stopwatch.Stop();

        Console.WriteLine($"{context.Request.Method} - Request Path: {context.Request.Path.ToString()} - So'rov vaqti: {stopwatch.ElapsedMilliseconds} ms");
    }
}