using Application.Common;
using Application.Person.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.Persons
{
  public class Persons_GetById
  {
    private readonly ILogger<Persons_GetById> _logger;
    private readonly IMediator _mediator;

    public Persons_GetById(ILogger<Persons_GetById> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("Persons_GetById")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Persons/getbyid/{id}")] 
      HttpRequest req)
    {
      var reqParams = AzureUtility.DictionaryToModel<PersonGetByIdParams>(req.RouteValues.ToDictionary());
      var res = await _mediator.Send(new PersonGetByIdQuery(reqParams));
      return new OkObjectResult(res);
    }
  }
}
