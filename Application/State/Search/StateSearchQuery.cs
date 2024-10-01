using Application.Models.Paging;
using Application.Models.State;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.State.Search
{
  public record StateSearchQuery(StateSearchParams req)
    : IRequest<PagedResponseDto<StateSearchRes>>
  {
  }
}
