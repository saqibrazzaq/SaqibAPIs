using Application.Common;
using Application.Country.Delete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.Countries
{
  public class Countries_Delete
  {
    private readonly ILogger<Countries_Delete> _logger;
    private readonly IMediator _mediator;

    public Countries_Delete(ILogger<Countries_Delete> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("Countries_Delete")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Countries/delete/{id}")]
        HttpRequest req)
    {
      var reqParams = AzureUtility.DictionaryToModel<CountryDeleteParams>(req.RouteValues.ToDictionary());
      await _mediator.Send(new CountryDeleteQuery(reqParams));
      return new NoContentResult();
    }

  }
}
