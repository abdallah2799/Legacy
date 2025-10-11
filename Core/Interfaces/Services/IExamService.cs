using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces.Services
{
    public interface IExamService
    {
        Task<IEnumerable<Exam>> GetAllExamsAsync();
        Task<IEnumerable<Exam>> GetActiveExamsAsync();
        Task<Exam?> GetExamWithQuestionsAsync(int examId);
        Task CreateExamAsync(Exam exam);
        Task UpdateExamStatusAsync(int examId, string status);
        Task<int> SubmitExamAsync(int studentId, int examId, Dictionary<int, List<int>> answers);
    }
}
