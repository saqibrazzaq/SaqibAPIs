using Application.Me.Get;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MeController : ControllerBase
  {
    private readonly IMediator _mediator;

    public MeController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var res = await _mediator.Send(new MeGetQuery(new MeGetParams()));
      return Ok(res);
    }
  }
}
