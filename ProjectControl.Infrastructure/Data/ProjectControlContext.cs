using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectControl.Core.Entities;
using ProjectControl.Infrastructure.Data.Configuration;

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
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());

            modelBuilder.ApplyConfiguration(new ActivityStatusTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ActivityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ProjectConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new UserActivityConfiguration());

            modelBuilder.ApplyConfiguration(new UserImageConfiguration());

            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());

            modelBuilder.ApplyConfiguration(new UserProjectConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
