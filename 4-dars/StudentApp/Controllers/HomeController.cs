
using Microsoft.AspNetCore.Mvc;

using StudentApp.Repository;

namespace StudentApp.Controllers;

public class HomeController : Controller
{

    private readonly IStudentRepository _studentRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public HomeController(IStudentRepository studentRepository, IWebHostEnvironment webHostEnvironment)
    {
        _studentRepository = studentRepository;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        var students = _studentRepository.GetAll();
        return View(students);
    }

    public IActionResult Detail(int id)
    {
        var student = _studentRepository.Get(id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    public IActionResult IndexJSON()
    {
        var students = _studentRepository.GetAll();
        return Json(students);
    }

    public IActionResult DetailJSON(int id)
    {
        var student = _studentRepository.Get(id);
        if (student == null)
        {
            return NotFound();
        }
        return Json(student);
    }

    public IActionResult IndexContent()
    {
        var students = _studentRepository.GetAll();
        return Content(students.ToString());
    }

    public IActionResult DetailContent(int id)
    {
        var student = _studentRepository.Get(id);
        if (student == null)
        {
            return NotFound();
        }
        return Content(student.ToString());
    }


    public IActionResult Admin()
    {
        return RedirectToAction("Index");
    }


    public ActionResult DownloadFile()
    {
        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Files", "Sample.pdf");

        Console.WriteLine("file");
        Console.WriteLine(_webHostEnvironment.WebRootPath);
        if (System.IO.File.Exists(filePath))
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf");
        }

        return NotFound();

    }


}

