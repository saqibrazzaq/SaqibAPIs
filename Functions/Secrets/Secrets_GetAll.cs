using Application.Secrets.GetAll;
using AzureServices;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions.Secrets
{
  public class Secrets_GetAll
  {
    private readonly ILogger<Secrets_GetAll> _logger;
    private readonly IMediator _mediator;

    public Secrets_GetAll(ILogger<Secrets_GetAll> logger, IMediator mediator)
    {
      _logger = logger;
      _mediator = mediator;
    }

    [Function("Secrets_GetAll")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Secrets/GetAll")] HttpRequest req)
    {
      _logger.LogInformation("Get all secrets from Azure");
      var res = await _mediator.Send(new SecretsGetAllQuery(new SecretsGetAllParams()));
      return new OkObjectResult(res);
    }
  }
}
