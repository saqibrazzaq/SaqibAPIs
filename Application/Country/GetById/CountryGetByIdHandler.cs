using Application.Models.Exceptions;
using Application.Models.Country;
using AutoMapper;
using Infrastructure.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Country.GetById
{
  public class CountryGetByIdHandler
    : IRequestHandler<CountryGetByIdQuery, CountryRes>
  {
    private readonly IRepositoryManager _rep;
    private readonly IMapper _mapper;
    public CountryGetByIdHandler(IRepositoryManager rep, IMapper mapper)
    {
      _rep = rep;
      _mapper = mapper;
    }

    public Task<CountryRes> Handle(CountryGetByIdQuery request, CancellationToken cancellationToken)
    {
      var entity = _rep.CountryRepository.FindAll()
        .Where(x => x.Id == request.req.Id)
        .FirstOrDefault();

      if (entity == null)
      {
        throw new NotFoundException($"No Country found with id {request.req.Id}");
      }

      return Task.FromResult(_mapper.Map<CountryRes>(entity));
    }
  }
}
