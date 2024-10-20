using Application.Models.Exceptions;
using Infrastructure.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.State.Delete
{
  public class StateDeleteHandler
    : IRequestHandler<StateDeleteQuery>
  {
    private readonly IRepositoryManager _rep;

    public StateDeleteHandler(IRepositoryManager rep)
    {
      _rep = rep;
    }

    public async Task Handle(StateDeleteQuery request, CancellationToken cancellationToken)
    {
      var entity = _rep.StateRepository.FindAll(true)
        .Where(x => x.Id == request.req.Id)
        .FirstOrDefault();
      if (entity == null) throw new NotFoundException($"No state found with id {request.req.Id}");

      Validate(request.req);

      _rep.StateRepository.Delete(entity);
      await _rep.SaveAsync();
    }

    private void Validate(StateDeleteParams req)
    {
      var personExists = _rep.PersonRepository.FindAll()
        .Where(x => x.StateId == req.Id)
        .Any();
      if (personExists) throw new BadRequestException($"Cannot delete state which has people.");
    }
  }
}
