using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;

public partial class Question
{
    public int QuestionId { get; set; }
    public int CourseId { get; set; }

    public string Body { get; set; }
    public int Marks { get; set; }

    // Discriminator
    public string Type { get; private set; }

    public int CreatedBy { get; set; }

    // ------------------------
    // Navigation Properties
    // ------------------------
    public virtual Course Course { get; set; }
    public virtual Instructor CreatedByNavigation { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
    public virtual ICollection<ExamQuestion> Exams { get; set; } = new List<ExamQuestion>();

    // ------------------------
    // Helper Property
    // ------------------------
    [NotMapped]
    public QuestionTypeEnum QuestionTypeEnum
    {
        get => Enum.TryParse<QuestionTypeEnum>(Type, true, out var result)
            ? result
            : throw new InvalidOperationException($"Invalid Question Type: {Type}");
        set => Type = value.ToString();
    }
}
