using School.Data.Models;

namespace School.Infrustructure.Interfaces;
public interface IStudentRepository : IGenericRepositoryAsync<Student>
{
    Task<List<Student>> GetStudentsListAsync();
}
