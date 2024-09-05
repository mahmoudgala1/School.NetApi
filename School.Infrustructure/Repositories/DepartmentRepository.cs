using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Infrustructure.Data;
using School.Infrustructure.Interfaces;

namespace School.Infrustructure.Repositories;
public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
{
    #region Fields
    private readonly DbSet<Department> _departments;
    #endregion

    #region Constructors
    public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
    #endregion

    #region Handle Functions

    #endregion
}
