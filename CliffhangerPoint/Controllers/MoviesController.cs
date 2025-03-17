using System;
using System.Runtime.CompilerServices;
using CliffhangerPoint.Commands;
using CliffhangerPoint.Database;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CliffhangerPoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
  private readonly ApplicationDbContext _context;
  private readonly ISender _sender;
  private readonly IMediator _mediator;

  public MoviesController(ApplicationDbContext context, ISender sender, IMediator mediator)
  {
    _context = context;
    _sender = sender;
    _mediator = mediator;
  }

  [HttpPost]
  [Route("Test")]
  public async Task<IActionResult> Create(CreateMovieCommand command)
  {
    var movieId = await _mediator.Send(command);
    return Ok(movieId);
  }

}
