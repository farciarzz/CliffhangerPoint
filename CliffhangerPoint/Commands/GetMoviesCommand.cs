using System;
using CliffhangerPoint.Models;
using MediatR;

namespace CliffhangerPoint.Commands;

public record GetMoviesCommand() : IRequest<List<Movie>>;
