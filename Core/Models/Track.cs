using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Track
    {
        public int TrackId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // ------------------------
        // Navigations
        // ------------------------
        public virtual ICollection<BranchTrack> BranchTracks { get; set; } = new List<BranchTrack>();
        public virtual ICollection<TrackCourse> TrackCourses { get; set; } = new List<TrackCourse>();
    }
}
