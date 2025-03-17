using System;
using CliffhangerPoint.Models;
using MediatR;

namespace CliffhangerPoint.Handlers;

public class ExampleHandler : IRequestHandler<ExampleRequest, IResult>
{
    public async Task<IResult> Handle(
      ExampleRequest request, CancellationToken cancellationToken)
    {
      await Task.Delay(1, cancellationToken);
      return Results.Ok(new
        { 
          message = $"Test {request.name}",
        });
    }
}