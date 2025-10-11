using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BranchTrack
    {
        
        public int BranchID { get; set; }
        public virtual Branch Branch { get; set; }

        public int TrackID { get; set; }
        public virtual Track Track { get; set; }

        // Extra field specific to this combination
        public int SupervisorID { get; set; }
        public virtual Instructor Supervisor { get; set; }
    }

}
