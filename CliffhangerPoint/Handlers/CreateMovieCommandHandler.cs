using System;
using MediatR;
using CliffhangerPoint.Commands;
using CliffhangerPoint.Database;
using CliffhangerPoint.Models;

namespace CliffhangerPoint.Handlers;

public class CreateMovieHandler : IRequestHandler<CreateMovieCommand, Guid>
{
    private readonly ApplicationDbContext _context;

    public CreateMovieHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
      var movie = new Movie
      {
        Id = Guid.NewGuid(),
        Name = request.Name,
        Year = request.Year,
        Genre = request.Genre
      };

      _context.Movies.Add(movie);
      await _context.SaveChangesAsync(cancellationToken);

      return movie.Id;
    }
}
