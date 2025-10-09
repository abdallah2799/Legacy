using Core.Models;
using Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> entity)
        {
            // -------------------------
            // Base Properties
            // -------------------------
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06F8CA6C29252");

            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.Body).IsRequired();
            entity.Property(e => e.Marks).IsRequired();
            entity.Property(e => e.Type).IsRequired().HasMaxLength(50);
            entity.Property(e => e.CourseId).HasColumnName("CourseID");

            // -------------------------
            // Relationships
            // -------------------------
            entity.HasOne(q => q.Course)
                  .WithMany(c => c.Questions)
                  .HasForeignKey(q => q.CourseId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Questions_Course");

            entity.HasOne(q => q.CreatedByNavigation)
                  .WithMany(i => i.Questions)
                  .HasForeignKey(q => q.CreatedBy)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Questions_CreatedBy");

            entity.HasMany(q => q.Exams)
                .WithOne(eq => eq.Question)
                .HasForeignKey(eq => eq.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamQuestions_Question");


            // -------------------------
            // TPH Mapping
            // -------------------------
            entity.HasDiscriminator<string>("Type")
                  .HasValue<TrueFalseQuestion>(QuestionTypeEnum.TrueFalse.ToString())
                  .HasValue<ChooseOneQuestion>(QuestionTypeEnum.ChooseOne.ToString())
                  .HasValue<ChooseAllQuestion>(QuestionTypeEnum.ChooseAll.ToString());
        }
    }
}
