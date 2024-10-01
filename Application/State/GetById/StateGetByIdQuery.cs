using Application.Models.State;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.State.GetById
{
  public record StateGetByIdQuery(StateGetByIdParams req)
    : IRequest<StateRes>
  {
  }
}
