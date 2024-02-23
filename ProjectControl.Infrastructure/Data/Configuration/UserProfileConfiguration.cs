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
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("user_profile");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("birth_date");

            builder.Property(e => e.CreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("creation_date");

            builder.Property(e => e.Fullname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fullname");

            builder.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastname");

            builder.Property(e => e.ModificationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("modification_date");

            builder.Property(e => e.Status).HasColumnName("status");

            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.HasOne(d => d.User)
                .WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_profile_users_id");
        }
    }
}
