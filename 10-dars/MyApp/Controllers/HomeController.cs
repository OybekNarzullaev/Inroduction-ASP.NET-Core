using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Services;

namespace MyApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITransientService _trService1;
    private readonly ITransientService _trService2;
    private readonly IScopedService _scService1;
    private readonly IScopedService _scService2;
    private readonly ISingletonService _siService1;
    private readonly ISingletonService _siService2;

    public HomeController(
        ILogger<HomeController> logger,
        ITransientService trService1,
        ITransientService trService2,
        IScopedService scService1,
        IScopedService scService2,
        ISingletonService siService1,
        ISingletonService siService2
        )
    {

        _logger = logger;
        _trService1 = trService1;
        _trService2 = trService2;
        _scService1 = scService1;
        _scService2 = scService2;
        _siService1 = siService1;
        _siService2 = siService2;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult LifeTimeTest()
    {

        var response = new
        {
            transient = new
            {
                Guid1 = _trService1.GetGuid(),
                Guid2 = _trService2.GetGuid(),
            },
            scoped = new
            {
                Guid1 = _scService1.GetGuid(),
                Guid2 = _scService2.GetGuid(),
            },
            singleton = new
            {
                Guid1 = _siService1.GetGuid(),
                Guid2 = _siService2.GetGuid(),
            }
        };

        return Ok(response);
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
