using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Repositories;
public class ProductController : Controller
{
    private readonly ProductRepository _repository;
    public ProductController(ProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var products = _repository.GetAll();
        return View(products);
    }

    public IActionResult CreateView()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (ModelState.IsValid)
        {
            _repository.Create(product);
            TempData["Message"] = $"`{product.Name}` qo'shildi";
            return RedirectToAction("Index");
        }
        return RedirectToAction("CreateView");
    }
}