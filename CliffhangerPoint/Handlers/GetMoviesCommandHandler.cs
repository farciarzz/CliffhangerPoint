using System;
using MediatR;
using CliffhangerPoint.Commands;
using CliffhangerPoint.Database;
using CliffhangerPoint.Models;
using CliffhangerPoint.Models.EnumType;
using Microsoft.EntityFrameworkCore;
using CliffhangerPoint.Controllers;

namespace CliffhangerPoint.Handlers;

public class GetMoviesCommandHandler : IRequestHandler<GetMoviesCommand, List<Movie>>
{
    private readonly ApplicationDbContext _context;

    public GetMoviesCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Movie>> Handle(GetMoviesCommand request, CancellationToken cancellationToken)
    {
        var movies = await _context.Movies.ToListAsync(cancellationToken);
        return movies;
    }
}
