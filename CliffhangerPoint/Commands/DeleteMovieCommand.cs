using System;
using CliffhangerPoint.Models;
using MediatR;

namespace CliffhangerPoint.Commands;

public record DeleteMovieCommand(Guid Id) : IRequest<bool>;
