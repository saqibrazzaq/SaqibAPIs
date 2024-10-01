using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
  public class RepositoryBase<T> : IRepositoryBase<T> where T : class
  {
    protected AppDbContext _context;

    public RepositoryBase(AppDbContext context)
    {
      _context = context;
    }

    public async Task CreateAsync(T? entity)
    {
      if (entity == null) { throw new ArgumentNullException(nameof(entity)); }
      await _context.Set<T>().AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<T> entities)
    {
      await _context.Set<T>().AddRangeAsync(entities);
    }

    public void Delete(T? entity)
    {
      if (entity == null) { throw new ArgumentNullException(nameof(entity)); }
      _context.Set<T>().Remove(entity);
    }

    public void DeleteMany(IEnumerable<T> entities)
    {
      _context.Set<T>().RemoveRange(entities);
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
      return !trackChanges ?
        _context.Set<T>()
          .AsNoTracking() :
        _context.Set<T>();
    }

    //public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
    //    bool trackChanges,
    //    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
    //{
    //  // Get query
    //  IQueryable<T> query = _context.Set<T>();

    //  // Apply filter
    //  query = query.Where(expression);

    //  // Include
    //  if (include != null)
    //  {
    //    query = include(query);
    //  }

    //  // Tracking
    //  if (!trackChanges)
    //    query.AsNoTracking();

    //  return query;
    //}
  }
}
