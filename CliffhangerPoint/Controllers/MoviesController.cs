using System;
using System.Net;
using System.Runtime.CompilerServices;
using CliffhangerPoint.Commands;
using CliffhangerPoint.Database;
using CliffhangerPoint.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CliffhangerPoint.Controllers;

[Route("api/[controller]")]
[Authorize]
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
  [Route("Create")]
  public async Task<IActionResult> Create(CreateMovieCommand command)
  {
    var movieId = await _mediator.Send(command);
    return Ok(movieId);
  }

  [HttpGet]
  [Route("GetMovies")]
  public async Task<List<Movie>> Get()
  {
    List<Movie> movies = await _mediator.Send(new GetMoviesCommand());
    return movies;
  }
}
