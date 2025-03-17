using System;
using CliffhangerPoint.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CliffhangerPoint.Database;

public class ApplicationDbContext : IdentityDbContext<User>
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
  {
  }

  public DbSet<Movie> Movies { get; set; }  

  protected override void OnModelCreating(ModelBuilder builder)
  {
      base.OnModelCreating(builder);

      builder.Entity<User>().Property(u => u.Initials).HasMaxLength(5);

      builder.HasDefaultSchema("identity");
  }
}
