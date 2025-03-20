using System;
using MediatR;
using CliffhangerPoint.Commands;
using CliffhangerPoint.Database;
using CliffhangerPoint.Models;
using CliffhangerPoint.Models.EnumType;
using Microsoft.EntityFrameworkCore;
using CliffhangerPoint.Controllers;

namespace CliffhangerPoint.Handlers;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public DeleteMovieCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies.FindAsync(request.Id);

        if (movie == null)
        {
            // Movie not found, return false or throw an exception
            return false; // Or throw new NotFoundException($"Movie with ID {request.MovieId} not found.");
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

