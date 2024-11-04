using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureServices
{
  public static class ConfigureServices
  {
    public static void ConfigureAzureServices(this IServiceCollection services)
    {
      services.AddScoped<IKeyVaultService, KeyVaultService>();
    }
  }
}
