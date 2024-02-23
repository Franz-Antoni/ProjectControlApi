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
    public class UserProjectConfiguration : IEntityTypeConfiguration<UserProject>
    {
        public void Configure(EntityTypeBuilder<UserProject> builder)
        {
            builder.ToTable("user_project");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("creation_date");

            builder.Property(e => e.ModificationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("modification_date");

            builder.Property(e => e.ProjectId).HasColumnName("project_id");

            builder.Property(e => e.UserType).HasColumnName("user_type");

            builder.Property(e => e.Status).HasColumnName("status");

            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.HasOne(d => d.Project)
                .WithMany(p => p.UserProjects)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_project_projects_id");

            builder.HasOne(d => d.User)
                .WithMany(p => p.UserProjects)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_project_users_id");
        }
    }
}
