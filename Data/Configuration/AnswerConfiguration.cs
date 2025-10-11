using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> entity)
        {
            entity.HasKey(a => a.AnswerId).HasName("PK__Answers__D48250249C0763D2");

            entity.Property(a => a.AnswerId).HasColumnName("AnswerID");

            entity.Property(a => a.Body)
                  .IsRequired()
                  .HasMaxLength(500); // نحط limit عشان consistency

            entity.Property(a => a.QuestionId).HasColumnName("QuestionID");

            entity.Property(a => a.IsCorrect)
                  .IsRequired()
                  .HasDefaultValue(false);

            // Relationship
            entity.HasOne(a => a.Question)
                  .WithMany(q => q.Answers)
                  .HasForeignKey(a => a.QuestionId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Answers_Question");
        }
    }
}
