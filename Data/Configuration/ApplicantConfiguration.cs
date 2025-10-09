using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    using Core.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> entity)
        {
            // Table name
            entity.ToTable("Applicants");

            // Primary Key
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd() // Identity
                .IsRequired();

            // Properties configuration
            entity.Property(e => e.SelectedBranches)
                .IsRequired(); 

            entity.Property(e => e.SelectedTracks)
                .IsRequired(); 

            entity.Property(e => e.AcceptedBranchId)
                .IsRequired(false);

            entity.Property(e => e.AcceptedTrackId)
                .IsRequired(false);

            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.Username)
                .IsRequired(false) // Allows null
                .HasMaxLength(100);

            entity.Property(e => e.PasswordHash)
                .IsRequired(false) // Allows null
                .HasMaxLength(255);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.Gender)
              .HasConversion<string>()   // Map enum → string
              .IsRequired(true)
              .HasMaxLength(8);

            entity.Property(e => e.Age)
                .IsRequired(true);

            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(e => e.ApplicationCode)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Status)
                .IsRequired()
                .HasConversion<string>() 
                .HasMaxLength(8);

            entity.Property(e => e.ApplicationPasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.CreatedAt)
                .IsRequired(false);

            entity.Property(e => e.UpdatedAt)
                .IsRequired(false);

            entity.Property(e => e.ToBeDeleted)
                .IsRequired()
                .HasDefaultValue(false); 

            // Indexes for better performance
            entity.HasIndex(e => e.Email)
                .IsUnique();

            entity.HasIndex(e => e.ApplicationCode)
                .IsUnique();

            
            entity.HasIndex(e => e.Status);
            entity.HasIndex(e => e.ToBeDeleted);
        }
    }
}
