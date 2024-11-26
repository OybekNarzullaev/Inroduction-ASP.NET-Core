using Microsoft.AspNetCore.Mvc;
using OnlineShop.Repositories;
using OnlineShop.Models;

namespace OnlineShop.Controllers;

public class ProductController : Controller
{
    private ProductRepository _repository;

    public ProductController(ProductRepository repository)
    {
        _repository = repository;
    }

    // List all products
    public IActionResult Index()
    {
        var products = _repository.GetAll();

        return View(products);
    }

    // View details of a product
    public IActionResult Details(int id)
    {
        var product = _repository.Get(id);
        if (product == null)
            return NotFound();

        return View(product);
    }

    // Create a new product (GET)
    public IActionResult CreateView()
    {
        return View();
    }

    // Create a new product (POST)
    [HttpPost]
    public IActionResult Create(Product product)
    {
        _repository.Create(product);
        return RedirectToAction(nameof(Index));
    }

    // Edit a product (GET)
    public IActionResult EditView(int id)
    {
        var product = _repository.Get(id);
        if (product == null)
            return NotFound();

        return View(product);
    }

    // Edit a product (POST)
    [HttpPost]
    public IActionResult Edit(Product updatedProduct)
    {
        int id = updatedProduct.Id;
        var product = _repository.Get(id);
        if (product == null)
            return NotFound();

        _repository.Edit(id, updatedProduct);

        return RedirectToAction(nameof(Index));
    }

    // Delete a product (GET)
    public IActionResult DeleteView(int id)
    {
        var product = _repository.Get(id);
        if (product == null)
            return NotFound();

        return View(product);
    }

    // Delete a product (POST)
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var product = _repository.Get(id);
        if (product == null)
            return NotFound();

        _repository.Delete(id);

        return RedirectToAction(nameof(Index));
    }
}