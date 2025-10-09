using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetByCourseAsync(int courseId);
        Task AddQuestionAsync(Question question);
        Task<Question?> GetWithAnswersAsync(int questionId);
    }
}
