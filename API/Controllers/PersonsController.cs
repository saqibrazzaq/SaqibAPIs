using Application.Person.Create;
using Application.Person.Delete;
using Application.Person.GetById;
using Application.Person.Search;
using Application.Person.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PersonsController : ControllerBase
  {
    private readonly IMediator _mediator;

    public PersonsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] PersonSearchParams req)
    {
      var res = await _mediator.Send(new PersonSearchQuery(req));
      return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] PersonGetByIdParams req)
    {
      var res = await _mediator.Send(new PersonGetByIdQuery(req));
      return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PersonCreateParams req)
    {
      var res = await _mediator.Send(new PersonCreateQuery(req));
      return Ok(res);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] PersonUpdateParams req)
    {
      var res = await _mediator.Send(new PersonUpdateQuery(req));
      return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] PersonDeleteParams req)
    {
      await _mediator.Send(new PersonDeleteQuery(req));
      return NoContent();
    }
  }
}
