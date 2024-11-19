namespace MiddlewareApp.middlewares;

class AdminBlockMiddleware
{
    private readonly RequestDelegate _next;

    public AdminBlockMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if(context.Request.Path.ToString().Contains("/admin"))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Taqiqlangan");
        }
        else 
        {
            await _next(context);
        }
    }
}