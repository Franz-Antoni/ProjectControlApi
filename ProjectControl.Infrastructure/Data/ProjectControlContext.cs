using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectControl.Core.Entities;

namespace ProjectControl.Infrastructure.Data
{
    public partial class ProjectControlContext : DbContext
    {
        public ProjectControlContext()
        {
        }

        public ProjectControlContext(DbContextOptions<ProjectControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; } = null!;
        public virtual DbSet<ActivityStatusType> ActivityStatusTypes { get; set; } = null!;
        public virtual DbSet<ActivityType> ActivityTypes { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserActivity> UserActivities { get; set; } = null!;
        public virtual DbSet<UserImage> UserImages { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;
        public virtual DbSet<UserProject> UserProjects { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("activities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActivityStatusTypeId).HasColumnName("activity_status_type_id");

                entity.Property(e => e.ActivityTypeId).HasColumnName("activity_type_id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("modification_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PlannedEndDate)
                    .HasColumnType("date")
                    .HasColumnName("planned_end_date");

                entity.Property(e => e.PlannedStartDate)
                    .HasColumnType("date")
                    .HasColumnName("planned_start_date");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.ActivityStatusType)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.ActivityStatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_activities_activity_status_type_id");

                entity.HasOne(d => d.ActivityType)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_activities_activity_type_id");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_activities_projects_id");
            });

            modelBuilder.Entity<ActivityStatusType>(entity =>
            {
                entity.ToTable("activity_status_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("modification_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ActivityType>(entity =>
            {
                entity.ToTable("activity_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("modification_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("projects");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("modification_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("modification_date");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password_salt");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<UserActivity>(entity =>
            {
                entity.ToTable("user_activity");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TypeCollaboration).HasColumnName("type_collaboration");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.UserActivities)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_activity_activities_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserActivities)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_activity_users_id");
            });

            modelBuilder.Entity<UserImage>(entity =>
            {
                entity.ToTable("user_image");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("modification_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("url");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserImages)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_image_users_id");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("user_profile");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("modification_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_profile_users_id");
            });

            modelBuilder.Entity<UserProject>(entity =>
            {
                entity.ToTable("user_project");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("creation_date");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("modification_date");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.UserProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_project_projects_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProjects)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_project_users_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
