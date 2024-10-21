using Application.Models.Exceptions;
using Infrastructure.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Person.Delete
{
  public class PersonDeleteHandler
    : IRequestHandler<PersonDeleteQuery>
  {
    private readonly IRepositoryManager _rep;

    public PersonDeleteHandler(IRepositoryManager rep)
    {
      _rep = rep;
    }

    public async Task Handle(PersonDeleteQuery request, CancellationToken cancellationToken)
    {
      var entity = _rep.PersonRepository.FindAll(true)
        .Where(x => x.Id == request.req.Id)
        .FirstOrDefault();
      if (entity == null) throw new NotFoundException($"No person found with id {request.req.Id}");

      _rep.PersonRepository.Delete(entity);
      await _rep.SaveAsync();
    }
  }
}
