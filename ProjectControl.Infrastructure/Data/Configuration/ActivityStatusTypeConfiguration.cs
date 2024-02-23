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
    public class ActivityStatusTypeConfiguration : IEntityTypeConfiguration<ActivityStatusType>
    {
        public void Configure(EntityTypeBuilder<ActivityStatusType> builder)
        {
            builder.ToTable("activity_status_type");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("creation_date");

            builder.Property(e => e.ModificationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("modification_date");

            builder.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        }
    }
}
