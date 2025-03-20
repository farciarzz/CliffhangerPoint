using System;
using CliffhangerPoint.Models;
using MediatR;

namespace CliffhangerPoint.Commands;

public record GetMovieCommand(Guid Id) : IRequest<Movie>;
