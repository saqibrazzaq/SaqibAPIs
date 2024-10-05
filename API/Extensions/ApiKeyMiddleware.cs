using API.Common;
using Application.Models.Exceptions;

namespace API.Extensions
{
  public class ApiKeyMiddleware
  {
    private readonly RequestDelegate _next;
    public ApiKeyMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      var httpMethod = context.Request.Method;
      if (httpMethod == "OPTIONS" || context.Request.Path.StartsWithSegments("/swagger"))
      { }
      else
      {
        // Proceed with API key validation
        if (!context.Request.Headers.TryGetValue("X_API_KEY", out var extractedApiKey))
        {
          //context.Response.StatusCode = 401;
          //await context.Response.WriteAsync("API Value is required.");
          throw new Exception("X_API_KEY is required in header.");
          //return;
        }

        var isValidKey = extractedApiKey == SecretUtility.APIKey;
        if (isValidKey == false)
        {
          throw new UnAuthorizedUserException("Unauthorized client. X_API_KEY is incorrect.");
        }
      }

      await _next(context);
    }
  }
}
