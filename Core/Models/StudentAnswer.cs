using System;

namespace Core.Models
{
    public class StudentAnswer
    {
        public int StudentAnswerId { get; set; }

        public int StudentExamId { get; set; }
        public int QuestionId { get; set; }

        // Nullable: ممكن الطالب يسيب السؤال بلا إجابة
        public int? AnswerId { get; set; }

        // هنخليها false by default (بدل nullable)
        public bool IsCorrect { get; set; }

        // ------------------------
        // Navigation
        // ------------------------
        public virtual Answer Answer { get; set; }
        public virtual Question Question { get; set; }
        public virtual StudentExam StudentExam { get; set; }
    }
}
