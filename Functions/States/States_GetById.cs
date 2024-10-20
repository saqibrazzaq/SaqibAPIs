using Application.Common;
using Application.State.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.States
{
  public class States_GetById
  {
    private readonly ILogger<States_GetById> _logger;
    private readonly IMediator _mediator;

    public States_GetById(ILogger<States_GetById> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("States_GetById")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "States/getbyid/{id}")]
      HttpRequest req)
    {
      var reqParams = AzureUtility.DictionaryToModel<StateGetByIdParams>(req.RouteValues.ToDictionary());
      var res = await _mediator.Send(new StateGetByIdQuery(reqParams));
      return new OkObjectResult(res);
    }
  }
}
