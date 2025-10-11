using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum ExamStatusEnum
    {
        Queued,      // Exam is scheduled but not started
        Started,     // Exam is currently running
        Finished,    // Exam has ended
        Cancelled    // Exam was cancelled
    }

}
