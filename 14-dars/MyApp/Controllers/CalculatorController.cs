using Microsoft.AspNetCore.Mvc;
using MyApp.Services;

[ApiController]
[Route("api/calculator")]
public class CalculatorController : ControllerBase
{
    private readonly ICalculatorService _calculatorService;
    public CalculatorController(ICalculatorService calculatorService)
    {
        _calculatorService = calculatorService;
    }
    [HttpGet("add")]
    public ActionResult<int> Add(int a, int b)
    {
        return _calculatorService.Add(a, b);
    }
}
