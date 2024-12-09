using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    public ProductController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        List<Product> products = await _dbContext.Products.ToListAsync();
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,ImageUrl")] Product newProduct)
    {
        if (ModelState.IsValid)
        {

            _dbContext.Add(newProduct);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(newProduct);
    }
}