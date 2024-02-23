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
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("activities");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.ActivityStatusTypeId).HasColumnName("activity_status_type_id");

            builder.Property(e => e.ActivityTypeId).HasColumnName("activity_type_id");

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

            builder.Property(e => e.PlannedEndDate)
                .HasColumnType("date")
                .HasColumnName("planned_end_date");

            builder.Property(e => e.PlannedStartDate)
                .HasColumnType("date")
                .HasColumnName("planned_start_date");

            builder.Property(e => e.ProjectId).HasColumnName("project_id");

            builder.Property(e => e.Status).HasColumnName("status");

            builder.HasOne(d => d.ActivityStatusType)
                .WithMany(p => p.Activities)
                .HasForeignKey(d => d.ActivityStatusTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_activities_activity_status_type_id");

            builder.HasOne(d => d.ActivityType)
                .WithMany(p => p.Activities)
                .HasForeignKey(d => d.ActivityTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_activities_activity_type_id");

            builder.HasOne(d => d.Project)
                .WithMany(p => p.Activities)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_activities_projects_id");
        }
    }
}
