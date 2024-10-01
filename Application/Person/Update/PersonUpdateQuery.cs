using Application.Models.Person;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Person.Update
{
  public record PersonUpdateQuery(PersonUpdateParams req)
    : IRequest<PersonRes>
  {
  }
}
