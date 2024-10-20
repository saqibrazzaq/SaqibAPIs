using Application.Common;
using Application.State.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.States
{
  public class States_Create
  {
    private readonly ILogger<States_Create> _logger;
    private readonly IMediator _mediator;

    public States_Create(ILogger<States_Create> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("States_Create")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "States/create")]
      HttpRequest req)
    {
      var reqParams = await AzureUtility.BodyToModel<StateCreateParams>(req.Body);
      var res = await _mediator.Send(new StateCreateQuery(reqParams));
      return new OkObjectResult(res);
    }
  }
}
