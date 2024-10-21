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

namespace Application.Person.Update
{
  public class PersonUpdateHandler
    : IRequestHandler<PersonUpdateQuery, PersonRes>
  {
    private readonly IRepositoryManager _rep;
    private readonly IMapper _mapper;
    public PersonUpdateHandler(IRepositoryManager rep, IMapper mapper)
    {
      _rep = rep;
      _mapper = mapper;
    }

    public async Task<PersonRes> Handle(PersonUpdateQuery request, CancellationToken cancellationToken)
    {
      var entity = _rep.PersonRepository.FindAll(true)
        .Where(x => x.Id == request.req.Id)
        .FirstOrDefault();
      if (entity == null) throw new NotFoundException($"No person found with id {request.req.Id}");

      Validate(request.req);

      _mapper.Map(request.req, entity);
      await _rep.SaveAsync();
      return _mapper.Map<PersonRes>(entity);
    }

    private void Validate(PersonUpdateParams req)
    {
      var emailExists = _rep.PersonRepository.FindAll()
        .Where(x => x.Id != req.Id && x.Email == req.Email)
        .Any();
      if (emailExists) throw new BadRequestException($"Email {req.Email} already exists.");
    }
  }
}
