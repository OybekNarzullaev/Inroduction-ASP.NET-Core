using Microsoft.EntityFrameworkCore;
using Moq;
using OnlineMarket.Controllers;
using OnlineMarket.Data;
using OnlineMarket.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

public class ProductApiControllerTests
{
    private readonly ApplicationDbContext _context;
    private readonly ProductApiController _controller;
    private readonly Mock<UserManager<User>> _userManagerMock;

    public ProductApiControllerTests()
    {
        // Set up InMemory Database for testing
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                           .UseInMemoryDatabase(databaseName: "InMemoryDb")
                           .Options;

        _context = new ApplicationDbContext(options);

        // Seed test data
        _context.Categories.Add(new Category { Name = "Electronics" });
        _context.Categories.Add(new Category { Name = "Books" });
        _context.SaveChanges();

        // Mock UserManager
        _userManagerMock = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(),
                                                      Mock.Of<IOptions<IdentityOptions>>(),
                                                      Mock.Of<IPasswordHasher<User>>(),
                                                      new IUserValidator<User>[0],
                                                      new IPasswordValidator<User>[0],
                                                      Mock.Of<ILookupNormalizer>(),
                                                      Mock.Of<IdentityErrorDescriber>(),
                                                      Mock.Of<IServiceProvider>(),
                                                      Mock.Of<ILogger<UserManager<User>>>());

        // Mock ClaimsPrincipal and User.Identity
        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, "test-user-id"), // Mock a user ID
        new Claim(ClaimTypes.Name, "Test User") // Mock user name
    };
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "mock"));

        // Set the mocked User for HttpContext
        var httpContext = new DefaultHttpContext();
        httpContext.User = user;

        // Set the controller's context to use the mocked HttpContext
        _controller = new ProductApiController(_context)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            }
        };
    }


    [Fact]
    public async Task GetAll_ShouldReturnListOfProducts()
    {
        var category = await _context.Categories.FirstAsync();
        // Arrange
        _context.Products.Add(new Product { Name = "Laptop", Price = 1000, CategoryId = category.Id, Stock = 10, Description = "Test" });
        _context.Products.Add(new Product { Name = "Book", Price = 15, CategoryId = category.Id, Stock = 50, Description = "Test" });
        _context.SaveChanges();

        // Act
        var result = await _controller.GetAll(null, null);

        // Assert
        Assert.IsType<OkObjectResult>(result);

    }

    [Fact]
    public async Task Create_ShouldReturnCreatedProduct()
    {
        // Arrange
        var product = new Product { Name = "Smartphone", Price = 500, CategoryId = 1, Stock = 20, Description = "Test" };

        // Act
        var result = await _controller.Create(product);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var createdProduct = Assert.IsType<Product>(createdResult.Value);
        Assert.Equal(product.Name, createdProduct.Name);
        Assert.Equal(product.Price, createdProduct.Price);
    }
}

