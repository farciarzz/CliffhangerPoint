using System;
using MediatR;
using CliffhangerPoint.Commands;
using CliffhangerPoint.Database;
using CliffhangerPoint.Models;
using CliffhangerPoint.Models.EnumType;
using Microsoft.EntityFrameworkCore;
using CliffhangerPoint.Controllers;

namespace CliffhangerPoint.Handlers;

public class GetMovieCommandHandler : IRequestHandler<GetMovieCommand, Movie>
{
    private readonly ApplicationDbContext _context;

    public GetMovieCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Movie> Handle(GetMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
        return movie;
    }
}

