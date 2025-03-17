using System;
using CliffhangerPoint.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CliffhangerPoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FirstController : ControllerBase
{
    private readonly IMediator _mediator;

    public FirstController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<BookController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new ExampleHandler()));
    }
}
