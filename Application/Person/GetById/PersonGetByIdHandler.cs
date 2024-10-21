using Application.Models.Exceptions;
using Application.Models.Person;
using AutoMapper;
using Infrastructure.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Person.GetById
{
  public class PersonGetByIdHandler
    : IRequestHandler<PersonGetByIdQuery, PersonRes>
  {
    private readonly IRepositoryManager _rep;
    private readonly IMapper _mapper;
    public PersonGetByIdHandler(IRepositoryManager rep, IMapper mapper)
    {
      _rep = rep;
      _mapper = mapper;
    }

    public Task<PersonRes> Handle(PersonGetByIdQuery request, CancellationToken cancellationToken)
    {
      var entity = _rep.PersonRepository.FindAll()
        .Where(x => x.Id == request.req.Id)
        .FirstOrDefault();
      if (entity == null) throw new NotFoundException($"No person found with id {request.req.Id}");

      return Task.FromResult(_mapper.Map<PersonRes>(entity));
    }
  }
}
