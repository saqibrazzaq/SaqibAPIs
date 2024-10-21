using Application.Common;
using Application.Person.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.Persons
{
  public class Persons_Create
  {
    private readonly ILogger<Persons_Create> _logger;
    private readonly IMediator _mediator;

    public Persons_Create(ILogger<Persons_Create> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("Persons_Create")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Persons/create")] 
      HttpRequest req)
    {
      var reqParams = await AzureUtility.BodyToModel<PersonCreateParams>(req.Body);
      var res = await _mediator.Send(new PersonCreateQuery(reqParams));
      return new OkObjectResult(res);
    }
  }
}
