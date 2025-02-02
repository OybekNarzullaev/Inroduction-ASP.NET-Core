using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Services;

public class ProductController : Controller
{

    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        List<Product> products = await _productService.GetAllProductsAsync();
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Price,Description,ImageUrl")] Product newProduct)
    {
        if (ModelState.IsValid)
        {

            await _productService.AddProductAsync(newProduct);
            return RedirectToAction(nameof(Index));
        }
        return View(newProduct);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([Bind("Id, Name,Price,Description,ImageUrl")] Product updatedProduct)
    {
        if (ModelState.IsValid)
        {

            await _productService.UpdateProductAsync(updatedProduct);
            TempData["message"] = $"'{updatedProduct.Name}' tahrirlandi";
            return RedirectToAction(nameof(Index));
        }
        return View(updatedProduct);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Product p)
    {
        bool isDeleted = await _productService.DeleteProductAsync(p.Id);
        if (isDeleted)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(p);
    }

}