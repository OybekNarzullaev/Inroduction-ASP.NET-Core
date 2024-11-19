using MiddlewareApp.middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.Use(async (context, next) => {
    Console.WriteLine("--------------Middleware Pipeline boshlandi-------------");
    Console.WriteLine("Middleware 1: So'rov keldi");
    await next.Invoke();
    Console.WriteLine("Middleware 1: Javob ketdi");
    Console.WriteLine("--------------Middleware Pipeline tugadi-------------");
});

app.Use(async (context, next) => {
    Console.WriteLine("Middleware 2: So'rov keldi");
    await next.Invoke();
    Console.WriteLine("Middleware 2: Javob ketdi");
});

// app.UseMiddleware<LoggerMiddleware>();
// app.UseMiddleware<AdminBlockMiddleware>();
app.UseMiddleware<RequestTimingMiddleware>();

app.Run(async context => {
    // throw new Exception("Salom men qandaydir xatoman");
    Console.WriteLine("Salom men teminal middleware man");
    await context.Response.WriteAsync("Salom Dunyo");
});


app.Run();
