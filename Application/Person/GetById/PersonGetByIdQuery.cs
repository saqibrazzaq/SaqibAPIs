using Application.Models.Person;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Person.GetById
{
  public record PersonGetByIdQuery(PersonGetByIdParams req)
    : IRequest<PersonRes>
  {
  }
}
