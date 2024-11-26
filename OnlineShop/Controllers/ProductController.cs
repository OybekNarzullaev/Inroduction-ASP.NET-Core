using OnlineShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers;

public class ProductController : Controller
{
    private readonly ProductRepository _productRepository;

    public ProductController(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public ActionResult Index()
    {
        var products = _productRepository.GetAll();
        return View(products);
    }

    public ActionResult Details(int id)
    {
        var product = _productRepository.Get(id);
        if (product == null)
            return NotFound();
        return View(product);
    }

    public ActionResult CreateView()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Product newProduct)
    {
        _productRepository.Create(newProduct);
        return RedirectToAction(nameof(Index));
    }

    public ActionResult EditView(int id)

    {
        var product = _productRepository.Get(id);
        if (product == null)
            return NotFound();
        return View(product);
    }

    [HttpPost]
    public ActionResult Edit(Product updatedProduct)
    {
        var id = updatedProduct.Id;
        var product = _productRepository.Get(id);
        if (product == null)
        {
            Console.WriteLine(id);
            return NotFound();
        }

        _productRepository.Edit(id, updatedProduct);
        return RedirectToAction(nameof(Index));
    }

    public ActionResult DeleteView(int id)
    {
        var product = _productRepository.Get(id);
        if (product == null)
            return NotFound();
        return View(product);
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
        _productRepository.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}