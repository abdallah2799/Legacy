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
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> entity)
        {
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            // Instructor → Branch
            entity.HasOne(i => i.Branch)
                .WithMany(b => b.Instructors)
                .HasForeignKey(i => i.BranchId)
                .IsRequired(true);

            // Instructor → ManagedBranch (One-to-One)
            entity.HasOne(i => i.ManagedBranch)
                .WithOne(b => b.Manager)
                .HasForeignKey<Branch>(b => b.ManagerId);
        }
    }
}
