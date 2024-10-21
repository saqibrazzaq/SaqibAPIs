using Application.Common;
using Application.Person.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.Persons
{
  public class Persons_Update
  {
    private readonly ILogger<Persons_Update> _logger;
    private readonly IMediator _mediator;

    public Persons_Update(ILogger<Persons_Update> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("Persons_Update")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Persons/update")] 
      HttpRequest req)
    {
      var reqParams = await AzureUtility.BodyToModel<PersonUpdateParams>(req.Body);
      var res = await _mediator.Send(new PersonUpdateQuery(reqParams));
      return new OkObjectResult(res);
    }
  }
}
