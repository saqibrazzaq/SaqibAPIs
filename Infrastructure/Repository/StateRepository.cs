using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
  public interface IStateRepository : IRepositoryBase<State> { }
  public class StateRepository : RepositoryBase<State>, IStateRepository
  {
    public StateRepository(AppDbContext context) : base(context)
    {
    }
  }
}
