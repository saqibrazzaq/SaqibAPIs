using Application.Models.Country;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Country.Create
{
  public record CountryCreateQuery(CountryCreateParams req)
    :IRequest<CountryRes>
  {
  }
}
