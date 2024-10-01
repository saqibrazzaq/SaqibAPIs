using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
  public interface ICountryRepository : IRepositoryBase<Country> { }
  public class CountryRepository : RepositoryBase<Country>, ICountryRepository
  {
    public CountryRepository(AppDbContext context) : base(context)
    {
    }
  }
}
