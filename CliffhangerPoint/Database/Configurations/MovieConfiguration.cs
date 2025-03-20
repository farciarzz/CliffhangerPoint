using CliffhangerPoint.Models;
using CliffhangerPoint.Models.EnumType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CliffhangerPoint.Database.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(255);
            builder.Property(e => e.Description).HasMaxLength(1000);
            builder.Property(e => e.Year);
            builder.Property(e => e.Genre).HasConversion(
                v => v.ToString(),
                v => (GenreType)Enum.Parse(typeof(GenreType), v)
            ).HasMaxLength(100);
            builder.Property(e => e.Duration).HasColumnType("time");
        }
    }
}