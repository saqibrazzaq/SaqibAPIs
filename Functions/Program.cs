using Application;
using Functions.Middleware;
using Google.Protobuf.WellKnownTypes;
using Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication(builder =>
    {
      builder.UseMiddleware<MyExceptionHandlerMiddleware>();
    })
    .ConfigureServices((appBuilder, services) =>
    {
      var configuration = appBuilder.Configuration;

      services.AddApplicationInsightsTelemetryWorkerService();
      services.ConfigureFunctionsApplicationInsights();

      services.ConfigureApplicationServices();
      services.ConfigureInfrastructureServices(configuration);
    })
    .Build();

host.Run();
