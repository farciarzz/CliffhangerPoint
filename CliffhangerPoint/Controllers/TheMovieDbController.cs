using System;
using System.Net;
using System.Runtime.CompilerServices;
using CliffhangerPoint.Commands;
using CliffhangerPoint.Controllers.Dtos;
using CliffhangerPoint.Database;
using CliffhangerPoint.Models;
using DM.MovieApi;
using DM.MovieApi.MovieDb.Movies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using DM.MovieApi.ApiResponse;

namespace CliffhangerPoint.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class TheMovieDbController : ControllerBase
{
  private readonly ApplicationDbContext _context;
  private readonly ISender _sender;
  private readonly IMediator _mediator;

  public TheMovieDbController(ApplicationDbContext context, ISender sender, IMediator mediator)
  {
    _context = context;
    _sender = sender;
    _mediator = mediator;
  }

  [HttpGet]
  [Route("GetMovies")]
  public async Task<string> Get()
  {
    var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;

    ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync( "Star Trek" );

    foreach( MovieInfo info in response.Results )
    {
        Console.WriteLine( $"{info.Title} ({info.ReleaseDate}): {info.Overview}" );
    }

    return "OK";
  }
}
