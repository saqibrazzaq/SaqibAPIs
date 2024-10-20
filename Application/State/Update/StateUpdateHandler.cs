using Application.Models.Exceptions;
using Application.Models.State;
using AutoMapper;
using Infrastructure.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.State.Update
{
  public class StateUpdateHandler
    : IRequestHandler<StateUpdateQuery, StateRes>
  {
    private readonly IRepositoryManager _rep;
    private readonly IMapper _mapper;
    public StateUpdateHandler(IRepositoryManager rep, IMapper mapper)
    {
      _rep = rep;
      _mapper = mapper;
    }

    public async Task<StateRes> Handle(StateUpdateQuery request, CancellationToken cancellationToken)
    {
      var entity = _rep.StateRepository.FindAll(true)
        .Where(x => x.Id == request.req.Id)
        .FirstOrDefault();
      if (entity == null) throw new NotFoundException($"No state found with id {request.req.Id}");

      Validate(request.req);

      _mapper.Map(request.req, entity);
      await _rep.SaveAsync();
      return _mapper.Map<StateRes>(entity);
    }

    private void Validate(StateUpdateParams req)
    {
      var nameExistsInSameCountry = _rep.StateRepository.FindAll()
        .Where(x => x.CountryId == req.CountryId && x.Id != req.Id && x.Name == req.Name)
        .Any();
      if (nameExistsInSameCountry) 
        throw new BadRequestException($"State name {req.Name} already exists in the same country.");
    }
  }
}
