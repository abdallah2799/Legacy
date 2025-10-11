using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace Core.Configurations
{
    public class CoursePolicyConfiguration : IEntityTypeConfiguration<CoursePolicy>
    {
        public void Configure(EntityTypeBuilder<CoursePolicy> entity)
        {
            entity.HasKey(e => e.PolicyId)
                  .HasName("PK__CoursePo__2E13394462810DAD");

            entity.Property(e => e.PolicyId).HasColumnName("PolicyID");
            entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");
            entity.Property(e => e.EffectiveTo).HasColumnType("datetime");
            entity.Property(e => e.PassPercentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TrackCourseId).HasColumnName("TrackCourseID");

            entity.HasOne(d => d.ManagedByNavigation)
                  .WithMany(p => p.CoursePolicies)
                  .HasForeignKey(d => d.ManagedBy)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_CoursePolicies_Manager");

            entity.HasOne(d => d.TrackCourse)
                  .WithMany(p => p.CoursePolicies)
                  .HasForeignKey(d => d.TrackCourseId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_CoursePolicies_TrackCourse");
        }
    }
}
