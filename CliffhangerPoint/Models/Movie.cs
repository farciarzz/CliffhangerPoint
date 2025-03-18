using System;
using System.ComponentModel.DataAnnotations;
using CliffhangerPoint.Models.EnumType;

namespace CliffhangerPoint.Models;

public class Movie 
{
  [Key]
  public Guid Id { get; set; }

  [Required]
  [MaxLength(255)]
  public string Title { get; set; }

  [MaxLength(1000)]
  public string? Description { get; set; }

  [DataType(DataType.Date)]
  public int Year { get; set; }

  [MaxLength(100)]
  public MovieGenre Genre { get; set; }

  public TimeSpan? Duration { get; set; }

}
