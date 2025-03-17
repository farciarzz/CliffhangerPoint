using System;
using MediatR;

namespace CliffhangerPoint.Requests;

public interface IHttpRequest : IRequest<IResult>
{

}
