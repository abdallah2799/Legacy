namespace Core.Models
{
    public class InstructorCourse
    {
        public int InstructorCourseId { get; set; }

        public int InstructorId { get; set; }
        public int CourseId { get; set; }

        // Default = false
        public bool IsOnline { get; set; }

        // ------------------------
        // Navigations
        // ------------------------
        public virtual Instructor Instructor { get; set; }
        public virtual Course Course { get; set; }
    }
}
