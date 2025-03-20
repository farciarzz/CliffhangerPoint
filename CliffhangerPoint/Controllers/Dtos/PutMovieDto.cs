using System;

namespace CliffhangerPoint.Controllers.Dtos;

public class PutMovieDto
{
  public Guid Id { get; set; }

  public string Title { get; set; }

  public string? Description { get; set; }

  public int Year { get; set; }

  public string Genre { get; set; }

  public TimeSpan? Duration { get; set; }

}
