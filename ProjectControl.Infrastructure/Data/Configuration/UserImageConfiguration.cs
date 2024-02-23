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
    public class UserImageConfiguration : IEntityTypeConfiguration<UserImage>
    {
        public void Configure(EntityTypeBuilder<UserImage> builder)
        {
            builder.ToTable("user_image");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("creation_date");

            builder.Property(e => e.ModificationDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("modification_date");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.Property(e => e.Status).HasColumnName("status");

            builder.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url");

            builder.Property(e => e.UserId).HasColumnName("user_id");

            builder.HasOne(d => d.User)
                .WithMany(p => p.UserImages)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_image_users_id");
        }
    }
}
