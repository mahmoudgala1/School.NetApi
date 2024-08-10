using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using School.Data.Models;
using School.Infrustructure.Data;
using School.Infrustructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrustructure.Repositories;
public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
{
    #region Fields
    private readonly ApplicationDbContext _dbcontext;
    #endregion

    #region Constructors
    public GenericRepositoryAsync(ApplicationDbContext context)
    {
        _dbcontext = context;
    }
    #endregion

    #region Handle Functions
    public async Task<T> AddAsync(T entity)
    {
        await _dbcontext.AddAsync(entity);
        await SaveChangesAsync();
        return entity;
    }

    public async Task AddRangeAsync(ICollection<T> entities)
    {
        await _dbcontext.AddRangeAsync(entities);
        await SaveChangesAsync();
    }

    public IDbContextTransaction BeginTransaction()
    {
        return _dbcontext.Database.BeginTransaction();
    }

    public void Commit()
    {
        _dbcontext.Database.CommitTransaction();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbcontext.Set<T>().Remove(entity);
        await SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(ICollection<T> entities)
    {
        foreach (var entity in entities)
        {
            _dbcontext.Entry(entity).State = EntityState.Deleted;
        }
        await _dbcontext.SaveChangesAsync();
        await SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbcontext.Set<T>().FindAsync(id);
    }

    public IQueryable<T> GetTableAsTracking()
    {
        return _dbcontext.Set<T>().AsQueryable();
    }

    public IQueryable<T> GetTableNoTracking()
    {
        return _dbcontext.Set<T>().AsNoTracking().AsQueryable();
    }

    public void RollBack()
    {
        _dbcontext.Database.RollbackTransaction();
    }

    public async Task SaveChangesAsync()
    {
        await _dbcontext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbcontext.Set<T>().Update(entity);
        await SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(ICollection<T> entities)
    {
        _dbcontext.Set<T>().UpdateRange(entities);
        await SaveChangesAsync();
    }
    #endregion
}
