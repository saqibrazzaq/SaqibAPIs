using Application.Common;
using Application.State.Search;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.States
{
  public class States_Search
  {
    private readonly ILogger<States_Search> _logger;
    private readonly IMediator _mediator;

    public States_Search(ILogger<States_Search> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("States_Search")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "States/search")] 
      HttpRequest req)
    {
      var reqParams = AzureUtility.QueryStringToModel<StateSearchParams>(req.QueryString.Value);
      var res = await _mediator.Send(new StateSearchQuery(reqParams));
      return new OkObjectResult(res);
    }
  }
}
