using System;
using MediatR;

namespace CliffhangerPoint.Commands;

public record CreateMovieCommand(Guid Id, string Name, int Year, string Genre) : IRequest<Guid>;
