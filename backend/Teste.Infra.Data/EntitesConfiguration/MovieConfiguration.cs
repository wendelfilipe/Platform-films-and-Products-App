using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Domain.Entites;

namespace Teste.Infra.Data.EntitesConfiguration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("movies", "platform");
            
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(p => p.Gender)
                .HasColumnName("gender")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Classification)
                .HasColumnName("classification");

            builder.Property(p => p.Date)
                .HasColumnName("date")
                .HasMaxLength(12)
                .IsRequired();

            builder.Property(p => p.Comment)
                .HasColumnName("comment")
                .HasMaxLength(450);

            builder.Property(p => p.Image)
                .HasColumnName("image")
                .HasMaxLength(100);
        }
    }
}