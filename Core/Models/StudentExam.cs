using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class StudentExam
    {
        public int StudentExamId { get; set; }

        public int StudentId { get; set; }
        public int ExamId { get; set; }

        public int? Score { get; set; }

        public DateTime? StartedAt { get; set; }
        public DateTime? SubmittedAt { get; set; }

        // ------------------------
        // Navigations
        // ------------------------
        public virtual Student Student { get; set; }
        public virtual Exam Exam { get; set; }

        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
    }
}
