using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PracticeExam : Exam
    {
        // Additional behaviors for Practice Exam
        public bool ShowCorrectAnswers => true;
    }
}
