using School.Data;
using School.Data.Models;

namespace School.Service.Interfaces;
public interface IStudentService
{
    Task<bool> IsNameExist(string name, int id);
    Task<List<Student>> GetStudentsListAsync();
    IQueryable<Student> GetStudentsQueryable();
    IQueryable<Student> FilterStudentPaginatedQueryable(StudnetOrderingEnum oredr, string search);
    Task<Student> GetStudentByIdAsync(int id);
    Task<string> AddStudentAsync(Student student);
    Task<string> EditStudentAsync(Student student);
    Task<string> DeleteStudentAsync(Student student);
}
