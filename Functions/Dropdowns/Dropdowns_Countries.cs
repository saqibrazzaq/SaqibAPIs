using Application.Common;
using Application.Dropdowns.Country;
using Application.Models.Dropdown;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.Dropdowns
{
  public class Dropdowns_Countries
  {
    private readonly ILogger<Dropdowns_Countries> _logger;
    private readonly IMediator _mediator;

    public Dropdowns_Countries(ILogger<Dropdowns_Countries> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("Dropdowns_Countries")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Dropdowns/country")] 
    HttpRequest req)
    {
      var reqParams = AzureUtility.QueryStringToModel<DropdownParams>(req.QueryString.Value);
      var res = await _mediator.Send(new CountryDropdownQuery(reqParams));
      return new OkObjectResult(res);
    }
  }
}
