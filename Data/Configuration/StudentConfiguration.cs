using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> entity)
        {
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.TrackId).HasColumnName("TrackID");
            // Student → Branch
            entity.HasOne(s => s.Branch)
                .WithMany(b => b.Students)
                .HasForeignKey(s => s.BranchId)
                .IsRequired(true);

            // Student → Track (unidirectional)
            entity.HasOne(s => s.Track)
                  .WithMany() // no navigation back
                  .HasForeignKey(s => s.TrackId)
                  .IsRequired(true);

        }
    }
}
