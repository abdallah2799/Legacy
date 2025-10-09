namespace Core.Models
{
    public partial class Branch
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int? ManagerId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Instructor Manager { get; set; }   // One-to-One
        public virtual ICollection<BranchTrack> BranchTracks { get; set; }= new List<BranchTrack>(); 
        public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
