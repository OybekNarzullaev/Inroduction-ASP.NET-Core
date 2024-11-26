using StudentApp.Models;

namespace StudentApp.Repository;

public interface IStudentRepository
{
    Student Get(int id);
    List<Student> GetAll();
}

class StudentRepository : IStudentRepository
{
    private readonly List<Student> _database;
    public StudentRepository()
    {
        _database = new List<Student>{
            new Student { Id = 1, Name = "Oybek", Age = 22, Major = "Computer Science" },
            new Student { Id = 2, Name = "Shaxzod", Age = 20, Major = "Biology" },
            new Student { Id = 3, Name = "Ibrohimbek", Age = 18, Major = "Math" },
        };
    }

    public List<Student> GetAll()
    {
        return _database;
    }

    public Student? Get(int id)
    {
        Student? student = _database.FirstOrDefault(s => s.Id == id);
        if (student == null)
            return null;
        return student;
    }

}