using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;
using MyApp.Services;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IProductService _service;
    private readonly ITransientService _trService;
    private readonly IScopedService _scService;
    private readonly ISingletonService _siService;

    public ProductController(
        ApplicationDbContext dbContext,
        IProductService service,
        ITransientService trService,
        IScopedService scService,
        ISingletonService siService
        )
    {
        _dbContext = dbContext;
        _service = service;
        _trService = trService;
        _scService = scService;
        _siService = siService;
    }

    public async Task<IActionResult> Index()
    {
        TempData["k11"] = _trService.GetGuid();
        TempData["k12"] = _trService.GetGuid();

        TempData["k21"] = _scService.GetGuid();
        TempData["k22"] = _scService.GetGuid();

        TempData["k31"] = _siService.GetGuid();
        TempData["k32"] = _siService.GetGuid();


        List<Product> products = await _service.GetAll();
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
        var product = await _service.GetById(id);
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