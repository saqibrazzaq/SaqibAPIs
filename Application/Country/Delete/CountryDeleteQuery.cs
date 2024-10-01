using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Country.Delete
{
  public record CountryDeleteQuery(CountryDeleteParams req)
    : IRequest
  {
  }
}
