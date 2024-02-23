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
    public class UserActivityConfiguration : IEntityTypeConfiguration<UserActivity>
    {
        public void Configure(EntityTypeBuilder<UserActivity> builder)
        {
            builder.ToTable("user_activity");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.ActivityId).HasColumnName("activity_id");

            builder.Property(e => e.CreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("creation_date");

            builder.Property(e => e.Status).HasColumnName("status");

            builder.Property(e => e.TypeCollaboration).HasColumnName("type_collaboration");

            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.HasOne(d => d.Activity)
                .WithMany(p => p.UserActivities)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_activity_activities_id");

            builder.HasOne(d => d.User)
                .WithMany(p => p.UserActivities)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_activity_users_id");
        }
    }
}
