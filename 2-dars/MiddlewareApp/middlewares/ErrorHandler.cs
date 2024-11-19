namespace MiddlewareApp.middlewares;

class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) 
    {
        try{
            await _next(context);
        }
        catch(Exception e){
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync($"Serverda noma'lum xatolik bo'ldi: {e.Message}");
        }
    }
}