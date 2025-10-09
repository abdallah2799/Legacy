using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public partial class Student : User
    {

        public int BranchId { get; set; }
        public int TrackId { get; set; }
        // Student-specific behavior can go here later
        public virtual Branch Branch { get; set; }
        public virtual Track Track { get; set; }

        public virtual ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();
    }
}
