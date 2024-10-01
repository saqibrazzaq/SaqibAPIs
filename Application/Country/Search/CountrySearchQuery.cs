using Application.Models.Country;
using Application.Models.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Country.Search
{
  public record CountrySearchQuery(CountrySearchParams req)
    : IRequest<PagedResponseDto<CountrySearchRes>>
  {
  }
}
