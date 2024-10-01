using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.State.Delete
{
  public record StateDeleteQuery(StateDeleteParams req)
    : IRequest
  {
  }
}
