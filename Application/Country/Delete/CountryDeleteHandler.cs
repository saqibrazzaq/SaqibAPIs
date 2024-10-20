using Application.Models.Exceptions;
using Infrastructure.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Country.Delete
{
  public class CountryDeleteHandler
    : IRequestHandler<CountryDeleteQuery>
  {
    private readonly IRepositoryManager _rep;
    
    public CountryDeleteHandler(IRepositoryManager rep)
    {
      _rep = rep;
    }

    public async Task Handle(CountryDeleteQuery request, CancellationToken cancellationToken)
    {
      var entity = _rep.CountryRepository.FindAll()
        .Where(x => x.Id == request.req.Id)
        .FirstOrDefault();
      if (entity == null) throw new NotFoundException($"No country found with id {request.req.Id}");

      Validate(request);

      _rep.CountryRepository.Delete(entity);
      await _rep.SaveAsync();
    }

    private void Validate(CountryDeleteQuery request)
    {
      var statesExist = _rep.StateRepository.FindAll()
        .Where(x => x.CountryId == request.req.Id)
        .Any();
      if (statesExist) throw new BadRequestException($"Cannot delete country with 1 or more states.");
    }
  }
}
