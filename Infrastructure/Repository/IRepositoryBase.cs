using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
  public interface IRepositoryBase<T>
  {
    IQueryable<T> FindAll(bool trackChanges = false);
    //IQueryable<T> FindByCondition(
    //    Expression<Func<T, bool>> expression,
    //    bool trackChanges,
    //    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null
    //    );
    Task CreateAsync(T? entity);
    Task CreateManyAsync(IEnumerable<T> entities);
    void Delete(T? entity);
    void DeleteMany(IEnumerable<T> entities);
  }
}
