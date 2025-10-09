using System.Collections.Generic;

namespace Core.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }

        //統一 التسمية مع باقي الجداول
        public string Body { get; set; }

        public bool IsCorrect { get; set; }

        // ------------------------
        // Navigations
        // ------------------------
        public virtual Question Question { get; set; }
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
    }
}
