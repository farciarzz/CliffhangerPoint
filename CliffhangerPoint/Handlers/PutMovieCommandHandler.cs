using System;
using MediatR;
using CliffhangerPoint.Commands;
using CliffhangerPoint.Database;
using CliffhangerPoint.Models;
using CliffhangerPoint.Models.EnumType;
using Microsoft.EntityFrameworkCore;
using CliffhangerPoint.Controllers;
using CliffhangerPoint.Controllers.Dtos;

namespace CliffhangerPoint.Handlers;

public class PutMovieCommandHandler : IRequestHandler<PutMovieCommand, Guid>
{
    private readonly ApplicationDbContext _context;

    public PutMovieCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(PutMovieCommand request, CancellationToken cancellationToken)
    {
      var test = request.putMovieDto.Genre;
      var movie = new Movie
      {
        Id = request.putMovieDto.Id,
        Title = request.putMovieDto.Title,
        Description = request.putMovieDto.Description,
        Year = request.putMovieDto.Year,
        Duration = request.putMovieDto.Duration,
        Genre = (GenreType)Enum.Parse(typeof(GenreType), request.putMovieDto.Genre, true)
      };

      _context.Movies.Update(movie);
      await _context.SaveChangesAsync(cancellationToken);

      return movie.Id;
    }
}

