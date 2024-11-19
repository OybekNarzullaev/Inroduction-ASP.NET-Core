var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseRouting();

app.MapGet("/hello", () => "Salom");

// route path
app.MapGet("/hello/{name}", (string name) => $"Salom, {name}!");

// route pathda cheklovlar
app.MapGet("/person/{name}/{year:int}/{month:int}/{day:int}", (string name, int year, int month, int day) =>
{
    return $"Ism:{name}; Kum:{day}; Oy:{month}; Yil:/{year}.";
});

// Faqat musbat son uchun marshrut
app.MapGet("/product/{id:int:min(1)}", (int id) =>
{
    return $"Product ID: {id}";
});

// JSON formatida javob
app.MapGet("/user/{id:int}", (int id) =>
{
    var user = new { Id = id, Name = "John Doe", Age = 30 };
    return Results.Json(user);
});

// Query string bilan ishlash
app.MapGet("/search", (string? query) =>
{
    if (string.IsNullOrWhiteSpace(query))
    {
        return Results.BadRequest("Query parametrlari yo'q.");
    }
    return Results.Ok($"Qidiruv kaliti: {query}");
});


// guruhlangan routelar
var productRoutes = app.MapGroup("/products");

productRoutes.MapGet("/", () => "All products");
productRoutes.MapGet("/{id:int}", (int id) => $"Product details for ID: {id}");
// productRoutes.MapPost("/", () => "Create a new product");


app.MapGet("/", () => "Hello World!");


app.Run();
