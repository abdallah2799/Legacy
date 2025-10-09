using Common.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACC19097F5");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4EEE82DF7").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.FullName).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Username).IsRequired().HasMaxLength(100);
            entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Gender)
              .HasConversion<string>()   // Map enum → string
              .IsRequired(true)
              .HasMaxLength(8);
            entity.Property(e => e.Age)
            .IsRequired();

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Role).IsRequired().HasMaxLength(50);
            
            

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            // -----------------------------
            // TPH Discriminator
            // -----------------------------
            entity.HasDiscriminator<string>("Role")
                .HasValue<Student>(UserRoleEnum.Student.ToString())
                .HasValue<Instructor>(UserRoleEnum.Instructor.ToString())
                .HasValue<Admin>(UserRoleEnum.Admin.ToString());

        }
    }
}
