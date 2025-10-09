using System.Collections.Generic;

namespace Core.Models
{
    public class Instructor : User
    {
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        // الكورسات اللي بيدرسها
        public virtual ICollection<InstructorCourse> InstructorCourses { get; set; } = new List<InstructorCourse>();

        // الأسئلة اللي أنشأها
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

        // الامتحانات اللي أنشأها
        public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
        
        // One-to-One: Instructor manages one Branch
        public virtual Branch ManagedBranch { get; set; }
    }
}
