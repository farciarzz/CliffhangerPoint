using System;
using CliffhangerPoint.Requests;
using MediatR;

namespace CliffhangerPoint;

public static class MinimalExtensions
{
    public static WebApplication MediateGet<TRequest>(
      this WebApplication app,
      string path) where TRequest : IHttpRequest
    {
      app.MapGet(path, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
      return app;
    }

    public static WebApplication MediatePost<TRequest>(this WebApplication app, string path)
      where TRequest : IHttpRequest
    {
      app.MapPost(path, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
      return app;
    }
}
