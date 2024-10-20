using Application.Common;
using Application.Country.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.Countries
{
  public class Countries_GetById
  {
    private readonly ILogger<Countries_GetById> _logger;
    private readonly IMediator _mediator;

    public Countries_GetById(ILogger<Countries_GetById> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("Countries_GetById")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Countries/getbyid/{id}")] 
      HttpRequest req)
    {
      var reqParams = AzureUtility.DictionaryToModel<CountryGetByIdParams>(req.RouteValues.ToDictionary());
      var res = await _mediator.Send(new CountryGetByIdQuery(reqParams));
      return new OkObjectResult(res);
    }
  }
}
