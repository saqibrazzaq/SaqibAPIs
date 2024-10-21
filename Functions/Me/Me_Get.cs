using Application.Me.Get;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.Me
{
  public class Me_Get
  {
    private readonly ILogger<Me_Get> _logger;
    private readonly IMediator _mediator;

    public Me_Get(ILogger<Me_Get> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("Me_Get")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "me")] 
      HttpRequest req)
    {
      var res = await _mediator.Send(new MeGetQuery(new MeGetParams()));
      return new OkObjectResult(res);
    }
  }
}
