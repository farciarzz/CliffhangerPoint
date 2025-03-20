using System;
using MediatR;
using CliffhangerPoint.Commands;
using CliffhangerPoint.Database;
using CliffhangerPoint.Models;
using CliffhangerPoint.Models.EnumType;

namespace CliffhangerPoint.Handlers;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Guid>
{
    private readonly ApplicationDbContext _context;

    public CreateMovieCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
      var movie = new Movie
      {
        Id = Guid.NewGuid(),
        Title = request.Title,
        Description = request.Description,
        Year = request.Year,
        Duration = request.Duration,
        Genre = (GenreType)Enum.Parse(typeof(GenreType), request.Genre, true)
      };

      _context.Movies.Add(movie);
      await _context.SaveChangesAsync(cancellationToken);

      return movie.Id;
    }
}
