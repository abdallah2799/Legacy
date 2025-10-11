namespace Core.Models
{
    public partial class TrackCourse
    {
        public int TrackCourseId { get; set; }
        public int TrackId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<CoursePolicy> CoursePolicies { get; set; } = new List<CoursePolicy>();
        public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
        public virtual Track Track { get; set; }
    }
}
