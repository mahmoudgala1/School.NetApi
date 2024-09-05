using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Data.Models;
using School.Infrustructure.Interfaces;
using School.Service.Interfaces;

namespace School.Service.Implementation;
public class StudentService : IStudentService
{
    #region Fields
    private readonly IStudentRepository _studentRepository;
    #endregion

    #region Constructors
    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    #endregion

    #region Handle Functions
    public async Task<List<Student>> GetStudentsListAsync()
    {
        return await _studentRepository.GetStudentsListAsync();
    }
    public async Task<Student> GetStudentByIdAsync(int id)
    {
        return _studentRepository.GetTableNoTracking()
                                 .Where(s => s.Id.Equals(id))
                                 .Include(s => s.Department)
                                 .FirstOrDefault()!;
    }
    public async Task<string> AddStudentAsync(Student student)
    {
        var studentResult = await _studentRepository.GetTableNoTracking()
                                 .Where(s => s.Name.Equals(student.Name))
                                 .FirstOrDefaultAsync()!;
        if (studentResult != null)
            return "Exist";
        await _studentRepository.AddAsync(student);
        return "Success";
    }

    public async Task<bool> IsNameExist(string name, int id)
    {
        var student = await _studentRepository.GetTableNoTracking().Where(std => std.Name == name).FirstOrDefaultAsync();
        if (student is null) return false;
        if (student != null && student.Id != id) return true;
        return false;
    }

    public async Task<string> EditStudentAsync(Student student)
    {
        await _studentRepository.UpdateAsync(student);
        return "Success";
    }

    public async Task<string> DeleteStudentAsync(Student student)
    {
        var trans = _studentRepository.BeginTransaction();
        try
        {
            await _studentRepository.DeleteAsync(student);
            await trans.CommitAsync();
            return "Success";
        }
        catch
        {
            await trans.RollbackAsync();
            return "Falid";
        }
    }

    public IQueryable<Student> GetStudentsQueryable()
    {
        return _studentRepository.GetTableNoTracking().Include(s => s.Department).AsQueryable();
    }

    public IQueryable<Student> FilterStudentPaginatedQueryable(StudnetOrderingEnum oredr, string search)
    {
        var querable = _studentRepository.GetTableNoTracking().Include(s => s.Department).AsQueryable();
        if (search is not null)
            querable = querable.Where(s => s.Name.Contains(search) || s.Address.Contains(search));
        switch (oredr)
        {
            case StudnetOrderingEnum.Id:
                querable = querable.OrderBy(s => s.Id);
                break;
            case StudnetOrderingEnum.Name:
                querable = querable.OrderBy(s => s.Name);
                break;
            case StudnetOrderingEnum.Address:
                querable = querable.OrderBy(s => s.Address);
                break;
            case StudnetOrderingEnum.DepartmentName:
                querable = querable.OrderBy(s => s.Department.Name);
                break;
        }
        return querable;
    }
    #endregion

}
