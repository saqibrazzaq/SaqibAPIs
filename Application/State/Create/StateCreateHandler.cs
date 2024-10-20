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

namespace Application.State.Create
{
  public class StateCreateHandler
    : IRequestHandler<StateCreateQuery, StateRes>
  {
    private readonly IRepositoryManager _rep;
    private readonly IMapper _mapper;
    public StateCreateHandler(IRepositoryManager rep, IMapper mapper)
    {
      _rep = rep;
      _mapper = mapper;
    }

    public async Task<StateRes> Handle(StateCreateQuery request, CancellationToken cancellationToken)
    {
      Validate(request);

      var entity = _mapper.Map<Domain.Entities.State>(request.req);
      await _rep.StateRepository.CreateAsync(entity);
      await _rep.SaveAsync();
      return _mapper.Map<StateRes>(entity);
    }

    private void Validate(StateCreateQuery request)
    {
      var nameExistsInSameCountry = _rep.StateRepository.FindAll()
        .Where(x => x.CountryId == request.req.CountryId && x.Name == request.req.Name)
        .Any();

      if (nameExistsInSameCountry) 
        throw new BadRequestException($"State {request.req.Name} already exists in this country.");
    }
  }
}
