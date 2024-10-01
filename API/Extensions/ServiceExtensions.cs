using API.Logger;
using Microsoft.AspNetCore.Diagnostics;

namespace API.Extensions
{
  public static class ServiceExtensions
  {
    public static void ConfigureEnvironmentVariables(this IServiceCollection services)
    {
      DotNetEnv.Env.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));
    }

    public static void ConfigureCors(this IServiceCollection services, IConfiguration config)
    {
      var origins = config.GetSection("CorsOrigins").Get<List<string>>();
      Console.WriteLine("Cors origins: " + origins?.FirstOrDefault());
      services.AddCors(options =>
      {
        options.AddDefaultPolicy(
                              policy =>
                              {
                                policy.WithOrigins(origins?.ToArray() ?? [])
                                  .AllowCredentials()
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()
                                  .WithHeaders(["X_API_KEY"]);
                              });
      });
    }

    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
      app.UseExceptionHandler(c => c.Run(async context =>
      {
        var exceptionFeature = context.Features
              .Get<IExceptionHandlerPathFeature>();
        var exception = exceptionFeature?.Error;

        var response = new { error = exception?.Message ?? "Unknown error" };
        await context.Response.WriteAsJsonAsync(response);
      }));
    }

    public static void ConfigureLoggerService(this IServiceCollection services)
    {
      services.AddSingleton<ILoggerManager, LoggerManager>();
    }
  }
}
