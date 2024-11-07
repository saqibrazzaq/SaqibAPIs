using Application.Common;
using Application.State.Search;
using Application.WebJobs.TextMessageSender;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.WebJobs
{
  public class WebJobs_TextMessageSender
  {
    private readonly ILogger<WebJobs_TextMessageSender> _logger;
    private readonly IMediator _mediator;
    public WebJobs_TextMessageSender(ILogger<WebJobs_TextMessageSender> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("WebJobs_TextMessageSender")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "WebJobs/TextMessageSender")]
      HttpRequest req)
    {
      _logger.LogInformation("WebJobs_TextMessageSender request.");
      var reqParams = AzureUtility.QueryStringToModel<TextMessageSenderParams>(req.QueryString.Value);
      var res = await _mediator.Send(new TextMessageSenderQuery(reqParams));
      return new OkObjectResult(res);
    }
  }
}
