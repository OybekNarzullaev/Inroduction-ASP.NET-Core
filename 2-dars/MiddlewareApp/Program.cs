using MiddlewareApp.middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.Use(async (context, next) => {
    Console.WriteLine("Middleware 1: So'rov keldi");
    await next.Invoke();
    Console.WriteLine("Middleware 1: Javob ketdi");
});

app.Use(async (context, next) => {
    Console.WriteLine("Middleware 2: So'rov keldi");
    await next.Invoke();
    Console.WriteLine("Middleware 2: Javob ketdi");
});

app.UseMiddleware<LoggerMiddleware>();
app.UseMiddleware<AdminBlockMiddleware>();

app.Run(async context => {
    Console.WriteLine("Salom men teminal middleware man");
    await context.Response.WriteAsync("Salom Dunyo");
});


app.Run();
