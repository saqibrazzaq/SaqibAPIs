using Application.Common;
using Application.State.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.States
{
  public class States_Update
  {
    private readonly ILogger<States_Update> _logger;
    private readonly IMediator _mediator;

    public States_Update(ILogger<States_Update> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("States_Update")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "States/update")] 
      HttpRequest req)
    {
      var reqParams = await AzureUtility.BodyToModel<StateUpdateParams>(req.Body);
      var res = await _mediator.Send(new StateUpdateQuery(reqParams));
      return new OkObjectResult(res);
    }
  }
}
