using dotnet.DataAccess;
using DataAccessLayer.Entity_Classes;

namespace dotnet;

public class Program
{
    static void Main(string[] args)
    {
        var studentDa = new JsonDa<Student>("students.json");
        var subjectDa = new JsonDa<Subject>("subjects.json");

        studentDa.Add(new Student { Id = 3, Name = "John", Age = 20, Class = "A" });
        studentDa.Add(new Student { Id = 4, Name = "Jane", Age = 21, Class = "B" });

        subjectDa.Add(new Subject { Id = 3, Name = "Math", Teacher = "Mr. Smith" });
        subjectDa.Add(new Subject { Id = 4, Name = "Science", Teacher = "Ms. Johnson" });

        var students = studentDa.GetAll();
        var subjects = subjectDa.GetAll();

        foreach (var student in students)
        {
            Console.WriteLine($"Student: {student.Name}, Age: {student.Age}, Class: {student.Class}");
        }
    }
}