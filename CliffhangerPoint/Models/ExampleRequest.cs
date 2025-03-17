using System;
using CliffhangerPoint.Requests;

namespace CliffhangerPoint.Models;

public class ExampleRequest : IHttpRequest
{
  public string message { get; set; }
  public string name {get; set;}
}
