using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Domain.Entites;

namespace Teste.Infra.Data.EntitesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user", "traffic");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id");
            
            builder.Property(p => p.Classification)
                .HasColumnName("classification")
                .IsRequired();
            
            builder.Property(p => p.MovieId)
                .HasColumnName("movie_id")
                .IsRequired();

            builder.HasOne(p => p.Movie)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.MovieId);
        }
    }
}