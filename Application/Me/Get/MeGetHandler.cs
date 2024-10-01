using Application.Models.Me;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Me.Get
{
  public class MeGetHandler
    : IRequestHandler<MeGetQuery, MyInfoDto>
  {
    public Task<MyInfoDto> Handle(MeGetQuery request, CancellationToken cancellationToken)
    {
      var myInfo = new MyInfoDto();
      return Task.FromResult(myInfo);
    }
  }
}
