using Application.Models.Country;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Country.Update
{
  public record CountryUpdateQuery(CountryUpdateParams req)
    : IRequest<CountryRes>
  {
  }
}
