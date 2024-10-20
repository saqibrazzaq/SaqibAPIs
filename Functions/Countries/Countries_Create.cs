using Application.Common;
using Application.Country.Create;
using Application.Country.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.Countries
{
  public class Countries_Create
  {
    private readonly ILogger<Countries_Create> _logger;
    private readonly IMediator _mediator;

    public Countries_Create(ILogger<Countries_Create> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("Countries_Create")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Countries/create")]
      HttpRequest req)
    {
      var reqParams = await AzureUtility.BodyToModel<CountryCreateParams>(req.Body);
      var res = await _mediator.Send(new CountryCreateQuery(reqParams));
      return new OkObjectResult(res);
    }
  }
}
