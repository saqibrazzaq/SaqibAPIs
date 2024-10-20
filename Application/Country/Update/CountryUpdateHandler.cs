using Application.Models.Country;
using Application.Models.Exceptions;
using AutoMapper;
using Infrastructure.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Country.Update
{
  public class CountryUpdateHandler
    : IRequestHandler<CountryUpdateQuery, CountryRes>
  {
    private readonly IRepositoryManager _rep;
    private readonly IMapper _mapper;
    public CountryUpdateHandler(IRepositoryManager rep, IMapper mapper)
    {
      _rep = rep;
      _mapper = mapper;
    }

    public async Task<CountryRes> Handle(CountryUpdateQuery request, CancellationToken cancellationToken)
    {
      var entity = _rep.CountryRepository.FindAll(true)
        .Where(x => x.Id == request.req.Id)
        .FirstOrDefault();
      if (entity == null) throw new NotFoundException($"No country found with id {request.req.Id}");

      Validate(request.req);

      _mapper.Map(request.req, entity);
      await _rep.SaveAsync();
      return _mapper.Map<CountryRes>(entity);
    }

    private void Validate(CountryUpdateParams req)
    {
      var nameExists = _rep.CountryRepository.FindAll()
        .Where(x => x.Name == req.Name && x.Id != req.Id)
        .Any();
      if (nameExists) throw new BadRequestException($"Country name {req.Name} already exists.");

      var codeExists = _rep.CountryRepository.FindAll()
        .Where(x => x.Code == req.Code && x.Id != req.Id)
        .Any();
      if (codeExists) throw new BadRequestException($"Country code {req.Code} already exists.");
    }
  }
}
