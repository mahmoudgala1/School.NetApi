using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Infrustructure.Interfaces;
using School.Service.Interfaces;

namespace School.Service.Implementation;
public class DepartmentService : IDepartmentService
{
    #region Fields
    private readonly IDepartmentRepository _departmentRepository;
    #endregion

    #region Constructors
    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }
    #endregion

    #region Handle Functions
    public async Task<Department> GetDepartmentById(int id)
    {
        return await _departmentRepository.GetTableNoTracking()
            .Where(d => d.Id == id)
            .Include(d => d.DepartmentSubjects).ThenInclude(s => s.Subject)
            .Include(d => d.Students)
            .Include(d => d.Instructors)
            .Include(d => d.Instructor)
            .FirstOrDefaultAsync();
    }
    #endregion
}
