using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectControl.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectControl.Infrastructure.Data.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("projects");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("creation_date");

            builder.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");

            builder.Property(e => e.ModificationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("modification_date");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.Property(e => e.Status).HasColumnName("status");
        }
    }
}
