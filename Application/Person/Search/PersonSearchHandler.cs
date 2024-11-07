using Application.Common;
using Application.Models.Paging;
using Application.Models.Person;
using AutoMapper;
using Common;
using Domain.Entities;
using Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Person.Search
{
  public class PersonSearchHandler
    : IRequestHandler<PersonSearchQuery, PagedResponseDto<PersonSearchRes>>
  {
    private readonly IRepositoryManager _rep;
    private readonly IMapper _mapper;
    public PersonSearchHandler(IRepositoryManager rep, IMapper mapper)
    {
      _rep = rep;
      _mapper = mapper;
    }

    public Task<PagedResponseDto<PersonSearchRes>> Handle(PersonSearchQuery request, CancellationToken cancellationToken)
    {
      var entities = _rep.PersonRepository.FindAll();

      if (request.req.CountryId != null)
      {
        entities = entities.Where(x => x.State.CountryId == request.req.CountryId);
      }
      if (request.req.StateId != null)
      {
        entities = entities.Where(x => x.StateId == request.req.StateId);
      }
      if (!string.IsNullOrEmpty(request.req.SearchText))
      {
        entities = entities.Where(x => x.FirstName.Contains(request.req.SearchText) ||
          x.LastName.Contains(request.req.SearchText) ||
          x.City.Contains(request.req.SearchText) ||
          x.Email.Contains(request.req.SearchText) ||
          x.Phone.Contains(request.req.SearchText));
      }

      var totalRows = entities.Count();

      entities = entities.Include(x => x.State.Country)
        .OrderBy(x => x.FirstName)
        .Skip((request.req.PageIndex ?? 0) * (request.req.PageSize ?? Constants.PAGE_SIZE))
        .Take(request.req.PageSize ?? Constants.PAGE_SIZE);

      var pagedRes = new PagedResponse<Domain.Entities.Person>(totalRows, entities.ToList());
      return Task.FromResult(_mapper.Map<PagedResponseDto<PersonSearchRes>>(pagedRes));
    }
  }
}
