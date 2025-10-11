namespace Core.Models
{
    public partial class CoursePolicy
    {
        public int PolicyId { get; set; }
        public int TrackCourseId { get; set; }
        public decimal PassPercentage { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public int ManagedBy { get; set; }

        public virtual User ManagedByNavigation { get; set; }
        public virtual TrackCourse TrackCourse { get; set; }
    }
}
