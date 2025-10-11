using System.Collections.Generic;

namespace Core.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        // ------------------------
        // Navigations
        // ------------------------
        public virtual ICollection<InstructorCourse> InstructorCourses { get; set; } = new List<InstructorCourse>();
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
        public virtual ICollection<TrackCourse> TrackCourses { get; set; } = new List<TrackCourse>();
    }
}
