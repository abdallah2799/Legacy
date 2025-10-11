using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class StudentExamConfiguration : IEntityTypeConfiguration<StudentExam>
    {
        public void Configure(EntityTypeBuilder<StudentExam> entity)
        {
            entity.HasKey(se => se.StudentExamId).HasName("PK__StudentE__C5794956A9DE0192");

            entity.Property(se => se.StudentExamId).HasColumnName("StudentExamID");
            entity.Property(se => se.StudentId).HasColumnName("StudentID");
            entity.Property(se => se.ExamId).HasColumnName("ExamID");

            entity.Property(se => se.Score);
            entity.Property(se => se.StartedAt).HasColumnType("datetime");
            entity.Property(se => se.SubmittedAt).HasColumnType("datetime");

            // Relationships
            entity.HasOne(se => se.Student)
                  .WithMany(s => s.StudentExams)
                  .HasForeignKey(se => se.StudentId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_StudentExams_Student");

            entity.HasOne(se => se.Exam)
                  .WithMany(e => e.StudentExams)
                  .HasForeignKey(se => se.ExamId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_StudentExams_Exam");
        }
    }
}
