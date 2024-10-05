using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dropdown
{
    public record DropdownQuery(DropdownParams req)
    : IRequest<List<DropdownRes>>
    {
    }
}
