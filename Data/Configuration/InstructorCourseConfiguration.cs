using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class InstructorCourseConfiguration : IEntityTypeConfiguration<InstructorCourse>
    {
        public void Configure(EntityTypeBuilder<InstructorCourse> entity)
        {
            entity.HasKey(ic => ic.InstructorCourseId)
                  .HasName("PK__Instruct__2724B1A9438B5974");

            entity.Property(ic => ic.InstructorCourseId).HasColumnName("InstructorCourseID");
            entity.Property(ic => ic.InstructorId).HasColumnName("InstructorID");
            entity.Property(ic => ic.CourseId).HasColumnName("CourseID");

            entity.Property(ic => ic.IsOnline)
                  .IsRequired()
                  .HasDefaultValue(false);

            // Relationships
            entity.HasOne(ic => ic.Instructor)
                  .WithMany(i => i.InstructorCourses)
                  .HasForeignKey(ic => ic.InstructorId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_InstructorCourses_Instructor");

            entity.HasOne(ic => ic.Course)
                  .WithMany(c => c.InstructorCourses)
                  .HasForeignKey(ic => ic.CourseId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_InstructorCourses_Course");
        }
    }
}
