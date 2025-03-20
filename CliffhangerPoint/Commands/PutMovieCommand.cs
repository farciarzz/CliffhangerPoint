using System;
using CliffhangerPoint.Controllers.Dtos;
using CliffhangerPoint.Models;
using MediatR;

namespace CliffhangerPoint.Commands;

public record PutMovieCommand(PutMovieDto putMovieDto) : IRequest<Guid>;
