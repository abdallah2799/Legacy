using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public partial class FinalExam : Exam
    {
        // Additional behaviors for Final Exam
        public bool ShowCorrectAnswers => false;
    }
}
