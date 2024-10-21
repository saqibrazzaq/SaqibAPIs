using Application.Common;
using Application.Person.Search;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.Persons
{
  public class Persons_Search
  {
    private readonly ILogger<Persons_Search> _logger;
    private readonly IMediator _mediator;

    public Persons_Search(ILogger<Persons_Search> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("Persons_Search")]
    public async Task<IActionResult> Run(
      [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Persons/search")] 
      HttpRequest req)
    {
      var reqParams = AzureUtility.QueryStringToModel<PersonSearchParams>(req.QueryString.Value);
      var res = await _mediator.Send(new PersonSearchQuery(reqParams));
      return new OkObjectResult(res);
    }
  }
}
