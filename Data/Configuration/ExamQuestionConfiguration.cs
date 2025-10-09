using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            builder.ToTable("ExamQuestions");

            builder.HasKey(eq => new { eq.ExamId, eq.QuestionId });

            builder.HasOne(eq => eq.Exam)
                   .WithMany(e => e.Questions)
                   .HasForeignKey(eq => eq.ExamId);

            builder.HasOne(eq => eq.Question)
                   .WithMany(q => q.Exams)
                   .HasForeignKey(eq => eq.QuestionId);
        }
    }

}
