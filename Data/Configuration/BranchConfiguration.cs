using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace Core.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> entity)
        {
            entity.HasKey(e => e.BranchId)
                  .HasName("PK__Branches__A1682FA58225D397");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");

            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.Property(e => e.Location)
                  .HasMaxLength(200);

            entity.Property(e => e.ManagerId)
                  .HasColumnName("ManagerID");

            entity.Property(e => e.CreatedAt)
                  .HasDefaultValueSql("(getdate())")
                  .HasColumnType("datetime");

            entity.Property(e => e.UpdatedAt)
                  .HasDefaultValueSql("(getdate())")
                  .HasColumnType("datetime");


            // Branch → Manager (Instructor) - مطلوب
            entity.HasOne(b => b.Manager)
                .WithOne(i => i.ManagedBranch)
                .HasForeignKey<Branch>(b => b.ManagerId)
                .OnDelete(DeleteBehavior.Restrict) // ممنوع حذف إنستركتور وهو مدير لبرانش
                .HasConstraintName("FK_Branch_Manager")
                .IsRequired(false); 

            // Index للمانجر
            entity.HasIndex(b => b.ManagerId)
                  .IsUnique()
                  .HasDatabaseName("IX_Branches_ManagerID");
        }
    }
}

