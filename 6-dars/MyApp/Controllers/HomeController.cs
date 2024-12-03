using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login(
        [FromRoute] int id,
        [FromQuery] string name
        )
    {
        ViewData["id"] = id;
        ViewData["name"] = name;

        ViewBag.Message = "Salom";

        var loginModel = new LoginViewModel();
        return View(loginModel);
    }

    [HttpPost]
    public IActionResult LoginPost(LoginViewModel model)
    {
        ViewBag.Email = model.Email;
        if (ModelState.IsValid)
        {
            // Replace this with actual authentication logic
            if (model.Email == "admin@mail.com" && model.Password == "password")
            {
                // Authenticate and redirect
                TempData["Message"] = "Tizimga xush kelibsiz";
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
        }


        return RedirectToAction("Login");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
