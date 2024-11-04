using Application.Models.Secrets;
using AzureServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Secrets.GetAll
{
  public class SecretsGetAllHandler
    : IRequestHandler<SecretsGetAllQuery, Dictionary<string, string>>
  {
    private readonly IKeyVaultService _keyVaultService;

    public SecretsGetAllHandler(IKeyVaultService keyVaultService)
    {
      _keyVaultService = keyVaultService;
    }

    public Task<Dictionary<string, string>> Handle(SecretsGetAllQuery request, CancellationToken cancellationToken)
    {
      return Task.FromResult(_keyVaultService.GetAll());
    }
  }
}
