using System;
using CliffhangerPoint.Database.Configurations;
using CliffhangerPoint.Models;
using CliffhangerPoint.Models.EnumType;
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
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("dbo");

        builder.ApplyConfiguration(new MovieConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
    }
}
