using Application.State.Create;
using Application.State.Delete;
using Application.State.GetById;
using Application.State.Search;
using Application.State.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StatesController : ControllerBase
  {
    private readonly IMediator _mediator;

    public StatesController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] StateSearchParams req)
    {
      var res = await _mediator.Send(new StateSearchQuery(req));
      return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] StateGetByIdParams req)
    {
      var res = await _mediator.Send(new StateGetByIdQuery(req));
      return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StateCreateParams req)
    {
      var res = await _mediator.Send(new StateCreateQuery(req));
      return Ok(res);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] StateUpdateParams req)
    {
      var res = await _mediator.Send(new StateUpdateQuery(req));
      return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] StateDeleteParams req)
    {
      await _mediator.Send(new StateDeleteQuery(req));
      return NoContent();
    }
  }
}
