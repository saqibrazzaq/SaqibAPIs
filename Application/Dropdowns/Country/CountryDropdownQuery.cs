using Application.Models.Dropdown;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dropdowns.Country
{
  public record CountryDropdownQuery(DropdownParams req)
    : IRequest<List<DropdownRes>>
  {
  }
}
