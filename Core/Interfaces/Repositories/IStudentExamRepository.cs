using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IStudentExamRepository : IGenericRepository<StudentExam>
    {
        Task<IEnumerable<StudentExam>> GetByStudentAsync(int studentId);
        Task<StudentExam?> GetWithAnswersAsync(int studentExamId);
        Task<int> CallCalculateScoreAsync(int studentExamId);
    }
}
