using Application.Models.Dropdown;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dropdowns.State
{
    public record StateDropdownQuery(DropdownParams req)
    : IRequest<List<DropdownRes>>
    {
    }
}
