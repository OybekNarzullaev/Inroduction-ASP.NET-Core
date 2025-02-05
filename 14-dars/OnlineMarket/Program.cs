using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.Data;
using OnlineMarket.Models;
using OnlineMarket.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// Add DbContext with SQLite (using connection string from configuration)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqlLiteConnection")));

// Configure Identity with custom User model and ApplicationDbContext
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configure the application cookie settings for Identity
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/AccessDenied";
});

// Add scoped services for business logic
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<CartService>();

var app = builder.Build();

// Initialize roles and other essential setup (if needed)
await SeedRoles.Initialize(app.Services);

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HTTPS redirection for production environments
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Static files like images, CSS, JS

app.UseRouting(); // Enable routing in the app

app.UseAuthentication(); // Authentication middleware for Identity
app.UseAuthorization(); // Authorization middleware for securing routes

// Configure the default route for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{Id?}");

app.Run();
