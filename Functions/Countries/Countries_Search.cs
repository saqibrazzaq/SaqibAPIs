using Application.Common;
using Application.Country.GetById;
using Application.Country.Search;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Web;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Functions.Countries
{
    public class Countries_Search
    {
        private readonly ILogger<Countries_Search> _logger;
        private readonly IMediator _mediator;

        public Countries_Search(ILogger<Countries_Search> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [Function("Countries_search")]
        public async Task<IActionResult> Search(
          [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Countries/search")]
          HttpRequest req)
        {
            var reqParams = AzureUtility.QueryStringToModel<CountrySearchParams>(req.QueryString.Value);
            var res = await _mediator.Send(new CountrySearchQuery(reqParams));
            return new OkObjectResult(res);
        }
    }
}
