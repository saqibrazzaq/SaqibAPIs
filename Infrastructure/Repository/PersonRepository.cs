using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
  public interface IPersonRepository : IRepositoryBase<Person> { }
  public class PersonRepository : RepositoryBase<Person>, IPersonRepository
  {
    public PersonRepository(AppDbContext context) : base(context)
    {
    }
  }
}
