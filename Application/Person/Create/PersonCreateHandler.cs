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

namespace Application.Person.Create
{
  public class PersonCreateHandler
    : IRequestHandler<PersonCreateQuery, PersonRes>
  {
    private readonly IRepositoryManager _rep;
    private readonly IMapper _mapper;
    public PersonCreateHandler(IRepositoryManager rep, IMapper mapper)
    {
      _rep = rep;
      _mapper = mapper;
    }

    public async Task<PersonRes> Handle(PersonCreateQuery request, CancellationToken cancellationToken)
    {
      Validate(request.req);

      var entity = _mapper.Map<Domain.Entities.Person>(request.req);
      await _rep.PersonRepository.CreateAsync(entity);
      await _rep.SaveAsync();
      return _mapper.Map<PersonRes>(entity);
    }

    private void Validate(PersonCreateParams req)
    {
      var emailExists = _rep.PersonRepository.FindAll()
        .Where(x => x.Email == req.Email)
        .Any();
      if (emailExists) throw new BadRequestException($"Email address {req.Email} already exists.");
    }
  }
}
