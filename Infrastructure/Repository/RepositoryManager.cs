using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
  public class RepositoryManager : IRepositoryManager
  {
    private readonly AppDbContext _context;
    private readonly Lazy<ICountryRepository> _countryRepository;
    private readonly Lazy<IStateRepository> _stateRepository;
    private readonly Lazy<IPersonRepository> _personRepository;
    public RepositoryManager(AppDbContext context)
    {
      _context = context;

      _countryRepository = new Lazy<ICountryRepository>(() => new CountryRepository(context));
      _stateRepository = new Lazy<IStateRepository>(() => new StateRepository(context));
      _personRepository = new Lazy<IPersonRepository>(() => new PersonRepository(context));
    }

    public ICountryRepository CountryRepository => _countryRepository.Value;
    public IStateRepository StateRepository => _stateRepository.Value;
    public IPersonRepository PersonRepository => _personRepository.Value;

    public async Task SaveAsync()
    {
      await _context.SaveChangesAsync();
    }
  }
}
