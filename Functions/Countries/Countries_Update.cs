using Application.Common;
using Application.Country.Create;
using Application.Country.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.Countries
{
  public class Countries_Update
  {
    private readonly ILogger<Countries_Update> _logger;
    private readonly IMediator _mediator;

    public Countries_Update(ILogger<Countries_Update> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("Countries_Update")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "put", Route = "Countries/update")]
        HttpRequest req)
    {
      var reqParams = await AzureUtility.BodyToModel<CountryUpdateParams>(req.Body);
      var res = await _mediator.Send(new CountryUpdateQuery(reqParams));
      return new OkObjectResult(res);
    }
  }
}
