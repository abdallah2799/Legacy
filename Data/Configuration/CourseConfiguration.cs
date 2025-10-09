using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> entity)
        {
            entity.HasKey(c => c.CourseId)
                  .HasName("PK__Courses__C92D7187C9326206");

            entity.Property(c => c.CourseId).HasColumnName("CourseID");

            entity.Property(c => c.Name)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.Property(c => c.Description)
                  .HasMaxLength(500);
        }
    }
}
