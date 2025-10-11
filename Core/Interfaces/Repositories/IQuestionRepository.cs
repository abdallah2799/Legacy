using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        Task<IEnumerable<Question>> GetByCourseAsync(int courseId);
        Task<IEnumerable<Question>> GetByTypeAsync(string type);
        Task<Question?> GetWithAnswersAsync(int questionId);
    }
}
