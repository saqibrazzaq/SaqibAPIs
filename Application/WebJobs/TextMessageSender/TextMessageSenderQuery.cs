using Application.Models.WebJobs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WebJobs.TextMessageSender
{
  public record TextMessageSenderQuery(TextMessageSenderParams req)
    : IRequest<TextMessageSenderRes>
  {
  }
}
