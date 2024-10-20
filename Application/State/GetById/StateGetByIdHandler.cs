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

namespace Application.State.GetById
{
  public class StateGetByIdHandler
    : IRequestHandler<StateGetByIdQuery, StateRes>
  {
    private readonly IRepositoryManager _rep;
    private readonly IMapper _mapper;
    public StateGetByIdHandler(IRepositoryManager rep, IMapper mapper)
    {
      _rep = rep;
      _mapper = mapper;
    }

    public Task<StateRes> Handle(StateGetByIdQuery request, CancellationToken cancellationToken)
    {
      var entity = _rep.StateRepository.FindAll()
        .Where(x => x.Id == request.req.Id)
        .FirstOrDefault();

      if (entity == null) throw new NotFoundException($"No state found with id {request.req.Id}");

      return Task.FromResult(_mapper.Map<StateRes>(entity));
    }
  }
}
