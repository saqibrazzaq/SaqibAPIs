using Application.Country.Create;
using Application.Country.Delete;
using Application.Country.GetById;
using Application.Country.Search;
using Application.Country.Update;
using Application.Models.Country;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CountriesController : ControllerBase
  {
    private readonly IMediator _mediator;

    public CountriesController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] CountrySearchParams req)
    {
      var res = await _mediator.Send(new CountrySearchQuery(req));
      return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] CountryGetByIdParams req)
    {
      var res = await _mediator.Send(new CountryGetByIdQuery(req));
      return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CountryCreateParams req)
    {
      var res = await _mediator.Send(new CountryCreateQuery(req));
      return Ok(res);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CountryUpdateParams req)
    {
      var res = await _mediator.Send(new CountryUpdateQuery(req));
      return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] CountryDeleteParams req)
    {
      await _mediator.Send(new CountryDeleteQuery(req));
      return NoContent();
    }
  }
}
