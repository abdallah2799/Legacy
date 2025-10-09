using Common.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> entity)
    {
        // Base Properties
        entity.HasKey(e => e.ExamId).HasName("PK__Exams__297521A7A4309009");
        entity.Property(e => e.ExamId).HasColumnName("ExamID");
        entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
        entity.Property(e => e.Type).IsRequired().HasMaxLength(50);
        entity.Property(e => e.TrackCourseId).HasColumnName("TrackCourseID");

        entity.Property(e => e.Status)
                .HasConversion<string>()     // Enum → String
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue(ExamStatusEnum.Queued);  


        entity.Property(e => e.CreatedAt)
              .HasDefaultValueSql("(getdate())")
              .HasColumnType("datetime");

        entity.Property(e => e.UpdatedAt)
              .HasDefaultValueSql("(getdate())")
              .HasColumnType("datetime");

        // Relationships
        entity.HasOne(e => e.CreatedByNavigation)
              .WithMany(i => i.Exams)
              .HasForeignKey(e => e.CreatedBy)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_Exams_CreatedBy");

        entity.HasOne(e => e.TrackCourse)
              .WithMany(tc => tc.Exams)
              .HasForeignKey(e => e.TrackCourseId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_Exams_TrackCourse");

        entity.HasMany(e => e.Questions)
      .WithOne(eq => eq.Exam)
      .HasForeignKey(eq => eq.ExamId)
      .OnDelete(DeleteBehavior.ClientSetNull)
      .HasConstraintName("FK_ExamQuestions_Exam");


        // TPH Mapping
        entity.HasDiscriminator<string>("Type")
              .HasValue<FinalExam>(ExamTypeEnum.Final.ToString())
              .HasValue<PracticeExam>(ExamTypeEnum.Practice.ToString());
    }
}
