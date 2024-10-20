using Application.Models.Country;
using Application.Models.Exceptions;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Country.Create
{
  public class CountryCreateHandler
    : IRequestHandler<CountryCreateQuery, CountryRes>
  {
    private readonly IRepositoryManager _rep;
    private readonly IMapper _mapper;
    public CountryCreateHandler(IRepositoryManager rep, IMapper mapper)
    {
      _rep = rep;
      _mapper = mapper;
    }

    public async Task<CountryRes> Handle(CountryCreateQuery request, CancellationToken cancellationToken)
    {
      Validate(request.req);

      var entity = _mapper.Map<Domain.Entities.Country>(request.req);
      await _rep.CountryRepository.CreateAsync(entity);
      await _rep.SaveAsync();
      return _mapper.Map<CountryRes>(entity);
    }

    private void Validate(CountryCreateParams req)
    {
      var nameExists = _rep.CountryRepository.FindAll()
        .Where(x => x.Name == req.Name)
        .Any();
      if (nameExists)
      {
        throw new BadRequestException($"Country name {req.Name} already exists.");
      }

      var codeExists = _rep.CountryRepository.FindAll()
        .Where(x => x.Code == req.Code)
        .Any();
      if (codeExists)
      {
        throw new BadRequestException($"Country code {req.Code} already exists.");
      }
    }
  }
}
