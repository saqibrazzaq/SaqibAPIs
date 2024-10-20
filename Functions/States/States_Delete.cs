using Application.Common;
using Application.State.Delete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.States
{
  public class States_Delete
  {
    private readonly ILogger<States_Delete> _logger;
    private readonly IMediator _mediator;

    public States_Delete(ILogger<States_Delete> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("States_Delete")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "States/delete/{id}")]
      HttpRequest req)
    {
      var reqParams = AzureUtility.DictionaryToModel<StateDeleteParams>(req.RouteValues.ToDictionary());
      await _mediator.Send(new StateDeleteQuery(reqParams));
      return new NoContentResult();
    }
  }
}
