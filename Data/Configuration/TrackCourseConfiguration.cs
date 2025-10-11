using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace Core.Configurations
{
    public class TrackCourseConfiguration : IEntityTypeConfiguration<TrackCourse>
    {
        public void Configure(EntityTypeBuilder<TrackCourse> entity)
        {
            entity.HasKey(e => e.TrackCourseId)
                  .HasName("PK__TrackCou__C105F51ADC10E12B");

            entity.Property(e => e.TrackCourseId).HasColumnName("TrackCourseID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.TrackId).HasColumnName("TrackID");

            entity.HasOne(d => d.Course)
                  .WithMany(p => p.TrackCourses)
                  .HasForeignKey(d => d.CourseId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TrackCourses_Course");

            entity.HasOne(d => d.Track)
                  .WithMany(p => p.TrackCourses)
                  .HasForeignKey(d => d.TrackId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TrackCourses_Track");
        }
    }
}
