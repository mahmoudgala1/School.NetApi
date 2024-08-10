using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Infrustructure.Data;
using School.Infrustructure.Interfaces;

namespace School.Infrustructure.Repositories;
public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
{
    #region Fields
    private readonly DbSet<Student> _students;
    #endregion

    #region Constructors
    public StudentRepository(ApplicationDbContext dbcontext) : base(dbcontext)
    {
        _students = dbcontext.Set<Student>();
    }
    #endregion

    #region Handle Functions
    public async Task<List<Student>> GetStudentsListAsync()
    {
        return await _students.Include(s => s.Department).ToListAsync();
    }
    #endregion
}
