using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IAnswerService
    {
        Task<Answer> GetByIdAsync(int answerId);
        Task<IEnumerable<Answer>> GetByQuestionAsync(int questionId);
        Task AddAnswerAsync(Answer answer);
        Task UpdateAnswerAsync(Answer answer);
        Task DeleteAnswerAsync(int answerId);
        Task ValidateQuestionAnswersAsync(int questionId);
    }
}