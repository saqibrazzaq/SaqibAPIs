using Application.Common;
using Application.Dropdowns.State;
using Application.Models.Dropdown;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.Dropdowns
{
  public class Dropdowns_State
  {
    private readonly ILogger<Dropdowns_State> _logger;
    private readonly IMediator _mediator;

    public Dropdowns_State(ILogger<Dropdowns_State> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("Dropdowns_State")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Dropdowns/state")]
      HttpRequest req)
    {
      var reqParams = AzureUtility.QueryStringToModel<DropdownParams>(req.QueryString.Value);
      var res = await _mediator.Send(new StateDropdownQuery(reqParams));
      return new OkObjectResult(res);
    }
  }
}
