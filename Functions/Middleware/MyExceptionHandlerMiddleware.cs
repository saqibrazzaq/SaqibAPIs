using System.Net;
using System.ServiceModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Http;
using Application.Models.Exceptions;


namespace Functions.Middleware
{
  public class MyExceptionHandlerMiddleware : IFunctionsWorkerMiddleware
  {
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
      try
      {
        await next.Invoke(context);
      }
      catch (Exception exception)
      {
        var logger = context.GetLogger<MyExceptionHandlerMiddleware>();

        var req = await context.GetHttpRequestDataAsync();
        var res = req!.CreateResponse();

        switch (exception)
        {
          case BadHttpRequestException ex:
            logger.LogError(exception.Message);

            req = await context.GetHttpRequestDataAsync();
            res = req!.CreateResponse();
            res.StatusCode = HttpStatusCode.BadRequest;

            await res.WriteStringAsync(ex.Message);
            context.GetInvocationResult().Value = res;
            break;

          case NotFoundException ex:
            logger.LogError(exception.Message);
            req = await context.GetHttpRequestDataAsync();
            res = req!.CreateResponse();
            res.StatusCode = HttpStatusCode.NotFound;

            await res.WriteAsJsonAsync(new ErrorDetails(404, ex.Message));
            context.GetInvocationResult().Value = res;
            break;

          default:
            logger.LogError(exception.Message);

            req = await context.GetHttpRequestDataAsync();
            res = req!.CreateResponse();
            res.StatusCode = HttpStatusCode.InternalServerError;

            //await res.WriteStringAsync("Internal service error. Please contact an administrator");
            await res.WriteAsJsonAsync(new ErrorDetails(500, exception.Message));
            context.GetInvocationResult().Value = res;
            break;
        }
      }
    }
  }
}
