using Application.Models.Secrets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Secrets.GetAll
{
  public record SecretsGetAllQuery(SecretsGetAllParams req)
    : IRequest<Dictionary<string, string>>
  {
  }
}
