using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
  public static class ConfigureServices
  {
    public static void ConfigureInfrastructureServices(this IServiceCollection services,
      IConfiguration config)
    {
      // Database context
      services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(config.GetConnectionString("SqlServer")));
      services.AddTransient<DapperContext>();

      // Repository manager
      services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
  }
}
