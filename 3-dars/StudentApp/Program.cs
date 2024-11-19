using StudentApp.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var students = new List<Student>
{
    new Student { Id = 1, Name = "Oybek", Age = 22, Major = "Computer Science" },
    new Student { Id = 2, Name = "Shaxzod", Age = 20, Major = "Biology" },
    new Student { Id = 3, Name = "Ibrohimbek", Age = 18, Major = "Math" },
};

// Read - Barcha studentlarni olish
app.MapGet("/students", () => Results.Json(students));

// Read - Bir studentni ID orqali olish
app.MapGet("/students/{id}", (int id) =>
{
    var student = students.FirstOrDefault(s => s.Id == id);
    return student is not null ? Results.Json(student) : Results.NotFound();
});

// Create - Yangi student qo‘shish
app.MapPost("/students", (Student student) =>
{
    student.Id = students.Max(s => s.Id) + 1;  // Yangi ID yaratish
    students.Add(student);
    return Results.Created($"/students/{student.Id}", student);
});

// Update - Studentni yangilash
app.MapPut("/students/{id}", (int id, Student updatedStudent) =>
{
    var student = students.FirstOrDefault(s => s.Id == id);
    if (student is null) return Results.NotFound();

    student.Name = updatedStudent.Name;
    student.Age = updatedStudent.Age;
    student.Major = updatedStudent.Major;
    return Results.Json(student);
});

// Delete - Studentni o‘chirish
app.MapDelete("/students/{id}", (int id) =>
{
    var student = students.FirstOrDefault(s => s.Id == id);
    if (student is null) return Results.NotFound();

    students.Remove(student);
    return Results.NoContent();
});


app.MapGet("/", () => "Hello World!");

app.Run();
