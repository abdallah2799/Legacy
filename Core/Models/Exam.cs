using Common.Enums;
using Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

public partial class Exam
{
    public int ExamId { get; set; }
    public int TrackCourseId { get; set; }
    public string Title { get; set; }
    public int DurationMinutes { get; set; }

    public DateTime? ScheduledAt { get; set; }

    // Discriminator (Final / Practice)
    public string Type { get; private set; }

    // Replace string with enum
    public ExamStatusEnum Status {  get; set; }

    [NotMapped]
    public string StatusDisplay => Status.ToString();

    public int? FullMark { get; set; }
    public int? PassMark { get; set; }
    public int CreatedBy { get; set; } // InstructorId
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // ------------------------
    // Navigation Properties
    // ------------------------
    public virtual Instructor CreatedByNavigation { get; set; }
    public virtual TrackCourse TrackCourse { get; set; }
    public virtual ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();

    public virtual ICollection<ExamQuestion> Questions { get; set; } = new List<ExamQuestion>();

    // ------------------------
    // Helper Property for Type enum
    // ------------------------
    [NotMapped]
    public ExamTypeEnum ExamTypeEnum
    {
        get => Enum.TryParse<ExamTypeEnum>(Type, true, out var result)
            ? result
            : throw new InvalidOperationException($"Invalid Exam Type: {Type}");
        set => Type = value.ToString();
    }
}
