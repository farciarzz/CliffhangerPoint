using System;

namespace CliffhangerPoint.Models;

public class Movie 
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public int Year { get; set; }
  public string Genre { get; set; }

}
