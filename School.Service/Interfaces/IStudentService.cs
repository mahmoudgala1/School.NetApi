using School.Data.Models;

namespace School.Service.Interfaces;
public interface IStudentService
{
    Task<bool> IsNameExist(string name, int id);
    Task<List<Student>> GetStudentsListAsync();
    Task<Student> GetStudentByIdAsync(int id);
    Task<string> AddStudentAsync(Student student);
    Task<string> EditStudentAsync(Student student);
    Task<string> DeleteStudentAsync(Student student);
}
