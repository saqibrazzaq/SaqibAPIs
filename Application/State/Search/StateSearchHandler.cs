using Application.Common;
using Application.Models.Paging;
using Application.Models.State;
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

namespace Application.State.Search
{
  public class StateSearchHandler
    : IRequestHandler<StateSearchQuery, PagedResponseDto<StateSearchRes>>
  {
    private readonly IRepositoryManager _rep;
    private readonly IMapper _mapper;
    public StateSearchHandler(IRepositoryManager rep, IMapper mapper)
    {
      _rep = rep;
      _mapper = mapper;
    }

    public Task<PagedResponseDto<StateSearchRes>> Handle(StateSearchQuery request, CancellationToken cancellationToken)
    {
      var entities = _rep.StateRepository.FindAll();

      if (request.req.CountryId != null)
      {
        entities = entities.Where(x => x.CountryId == request.req.CountryId);
      }
      if (!string.IsNullOrEmpty(request.req.SearchText))
      {
        entities = entities.Where(x => (x.Name??"").Contains(request.req.SearchText));
      }

      var totalRows = entities.Count();

      entities = entities.Include(x => x.Country)
        .Skip((request.req.PageIndex ?? 0) * (request.req.PageSize ?? Constants.PAGE_SIZE))
        .Take(request.req.PageSize ?? Constants.PAGE_SIZE);

      var pagedRes = new PagedResponse<Domain.Entities.State>(totalRows, entities.ToList());
      return Task.FromResult(_mapper.Map<PagedResponseDto<StateSearchRes>>(pagedRes));
    }
  }
}
