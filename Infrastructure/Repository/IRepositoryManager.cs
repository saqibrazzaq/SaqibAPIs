using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
  public interface IRepositoryManager
  {
    ICountryRepository CountryRepository { get; }
    IStateRepository StateRepository { get; }
    IPersonRepository PersonRepository { get; }
    Task SaveAsync();
  }
}
