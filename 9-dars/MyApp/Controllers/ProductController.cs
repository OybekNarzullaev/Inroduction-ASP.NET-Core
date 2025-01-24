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

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([Bind("Name,Price,Description,ImageUrl")] Product updatedProduct)
    {
        if (ModelState.IsValid)
        {
            int Id = updatedProduct.Id;
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == Id);
            if (product == null)
            {
                return NotFound();
            }
            _dbContext.Update(updatedProduct);
            await _dbContext.SaveChangesAsync();
            TempData["message"] = $"'{updatedProduct.Name}' tahrirlandi";
            return RedirectToAction(nameof(Index));
        }
        return View(updatedProduct);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Product p)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(product => product.Id == p.Id);
        if (product != null)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

}