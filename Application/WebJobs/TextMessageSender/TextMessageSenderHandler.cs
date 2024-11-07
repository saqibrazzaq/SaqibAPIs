using Application.Models.WebJobs;
using Azure.Storage.Queues;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WebJobs.TextMessageSender
{
  public class TextMessageSenderHandler
    : IRequestHandler<TextMessageSenderQuery, TextMessageSenderRes>
  {
    private readonly QueueClient _queueClient;

    public TextMessageSenderHandler(QueueClient queueClient)
    {
      _queueClient = queueClient;
    }

    public async Task<TextMessageSenderRes> Handle(TextMessageSenderQuery request, CancellationToken cancellationToken)
    {
      var msgRes = $"Received: {request.req.Message}";
      await _queueClient.SendMessageAsync(msgRes);
      return new TextMessageSenderRes { Message = msgRes };
    }
  }
}
