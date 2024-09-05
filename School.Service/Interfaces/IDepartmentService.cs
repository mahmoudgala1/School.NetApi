using School.Data.Models;

namespace School.Service.Interfaces;

public interface IDepartmentService
{
    Task<Department> GetDepartmentById(int id);
}
