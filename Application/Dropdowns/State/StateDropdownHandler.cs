using Application.Common;
using Application.Models.Dropdown;
using AutoMapper;
using Common;
using Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dropdowns.State
{
  public class StateDropdownHandler
  : IRequestHandler<StateDropdownQuery, List<DropdownRes>>
  {
    private readonly IRepositoryManager _rep;
    private readonly IMapper _mapper;
    public StateDropdownHandler(IRepositoryManager rep, IMapper mapper)
    {
      _rep = rep;
      _mapper = mapper;
    }

    public Task<List<DropdownRes>> Handle(StateDropdownQuery request, CancellationToken cancellationToken)
    {
      var entities = _rep.StateRepository.FindAll();

      if (request.req.Id != null)
      {
        entities = entities.Where(x => x.Id == request.req.Id);
      }

      if (!string.IsNullOrEmpty(request.req.SearchText))
      {
        entities = entities.Where(x => (x.Name ?? "").Contains(request.req.SearchText) ||
          (x.Country.Name ?? "").Contains(request.req.SearchText));
      }

      entities = entities.Include(x => x.Country)
        .OrderBy(x => x.Name)
        .Skip(0)
        .Take(Constants.PAGE_SIZE);

      var dtos = _mapper.Map<List<DropdownRes>>(entities.ToList());
      return Task.FromResult(dtos);
    }
  }
}
