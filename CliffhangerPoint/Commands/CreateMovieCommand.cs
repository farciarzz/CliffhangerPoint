using System;
using MediatR;

namespace CliffhangerPoint.Commands;

public record CreateMovieCommand(string Name, int Year, string Genre) : IRequest<Guid>;
