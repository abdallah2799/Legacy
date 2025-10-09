using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IStudentAnswerRepository : IGenericRepository<StudentAnswer>
    {
        Task<IEnumerable<StudentAnswer>> GetAnswersByExamAsync(int examId, int studentId);
    }
}
