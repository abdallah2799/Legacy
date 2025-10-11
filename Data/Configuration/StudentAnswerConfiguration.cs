using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class StudentAnswerConfiguration : IEntityTypeConfiguration<StudentAnswer>
    {
        public void Configure(EntityTypeBuilder<StudentAnswer> entity)
        {
            entity.HasKey(sa => sa.StudentAnswerId).HasName("PK__StudentA__6E3EA4E506E73BB3");

            entity.Property(sa => sa.StudentAnswerId).HasColumnName("StudentAnswerID");
            entity.Property(sa => sa.StudentExamId).HasColumnName("StudentExamID");
            entity.Property(sa => sa.QuestionId).HasColumnName("QuestionID");
            entity.Property(sa => sa.AnswerId).HasColumnName("AnswerID");

            entity.Property(sa => sa.IsCorrect)
                  .IsRequired()
                  .HasDefaultValue(false);

            // Relationships
            entity.HasOne(sa => sa.Answer)
                  .WithMany(a => a.StudentAnswers)
                  .HasForeignKey(sa => sa.AnswerId)
                  .HasConstraintName("FK_StudentAnswers_Answer");

            entity.HasOne(sa => sa.Question)
                  .WithMany(q => q.StudentAnswers)
                  .HasForeignKey(sa => sa.QuestionId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_StudentAnswers_Question");

            entity.HasOne(sa => sa.StudentExam)
                  .WithMany(se => se.StudentAnswers)
                  .HasForeignKey(sa => sa.StudentExamId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_StudentAnswers_StudentExam");
        }
    }
}
