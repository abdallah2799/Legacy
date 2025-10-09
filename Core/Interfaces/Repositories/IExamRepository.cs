using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IExamRepository : IGenericRepository<Exam>
    {
        Task<IEnumerable<Exam>> GetActiveExamsAsync();
        Task<IEnumerable<Exam>> GetByTrackCourseAsync(int trackCourseId);
        Task<Exam?> GetExamWithQuestionsAsync(int examId);
    }
}
