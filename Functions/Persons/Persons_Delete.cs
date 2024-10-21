using Application.Common;
using Application.Person.Delete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.Persons
{
  public class Persons_Delete
  {
    private readonly ILogger<Persons_Delete> _logger;
    private readonly IMediator _mediator;

    public Persons_Delete(ILogger<Persons_Delete> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("Persons_Delete")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "Persons/delete/{id}")] 
      HttpRequest req)
    {
      var reqParams = AzureUtility.DictionaryToModel<PersonDeleteParams>(req.RouteValues.ToDictionary());
      await _mediator.Send(new PersonDeleteQuery(reqParams));
      return new NoContentResult();
    }
  }
}
