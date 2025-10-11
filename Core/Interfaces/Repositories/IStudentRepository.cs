using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<IEnumerable<Student>> GetByTrackAsync(int trackId);
        Task<IEnumerable<Student>> GetByBranchAsync(int branchId);
        Task<IEnumerable<Exam>> GetExamsAsync(int studentId);
        Task<StudentExam?> GetExamAttemptAsync(int studentId, int examId);
        Task<IEnumerable<StudentAnswer>> GetAnswersForExamAsync(int studentId, int examId);
        Task<Track?> GetTrackAsync(int studentId);
        Task<Student?> GetFullDataAsync(int studentId);
    }
}
