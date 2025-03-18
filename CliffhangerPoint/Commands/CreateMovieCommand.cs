using System;
using MediatR;

namespace CliffhangerPoint.Commands;

public record CreateMovieCommand(
  string Title,
  string Description,
  int Year,
  TimeSpan Duration,
  string Genre
  ) : IRequest<Guid>;
