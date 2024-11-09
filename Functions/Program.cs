using Application;
using Azure.Identity;
using Azure.Storage.Queues;
using AzureServices;
using Common;
using Functions.Middleware;
using Google.Protobuf.WellKnownTypes;
using Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = new HostBuilder()
  .ConfigureAppConfiguration(config => config
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appSettings.json")
      .AddEnvironmentVariables())
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
      services.ConfigureAzureServices();

      services.AddAzureClients(clientBuilder =>
      {
        // Register clients for each service
        //clientBuilder.AddSecretClient(configuration.GetSection("KeyVault"));
        //clientBuilder.AddClient<QueueClient, QueueClientOptions>((_, _, _) =>
        //{
        //  var connectionString = configuration["AzureWebJobsStorage"];
        //  var queueName = Constants.MESSAGE_QUEUE_NAME;
        //  return new QueueClient(connectionString, queueName);
        //});

        // Set a credential for all clients to use by default
        //DefaultAzureCredential credential = new();
        //clientBuilder.UseCredential(credential);
      });
    })
    .Build();

host.Run();
