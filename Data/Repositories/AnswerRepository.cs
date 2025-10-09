using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly LegacyDbContext _context;

        public AnswerRepository(LegacyDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Answer entity)
        {
              await  _context.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Answers.FindAsync(id);
            if (entity != null)
            {
                _context.Answers.Remove(entity);
            }
            else
            {
                throw new KeyNotFoundException($"Answer with ID {id} not found.");
            }
        }

        public async Task DeleteAsync(Answer entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Answers.Remove(entity);
        }
        public async Task<IEnumerable<Answer>> FindAsync(Expression<Func<Answer, bool>> predicate)
        {
            return await _context.Answers.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Answer>> GetAllAsync()
        {
            return await _context.Answers.ToListAsync();
        }

        public async Task<IEnumerable<Answer>> GetAnswersForQuestionAsync(int questionId)
        {
            return await FindAsync(a => a.QuestionId == questionId);
        }

        public async Task<Answer> GetByIdAsync(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
            {
                throw new KeyNotFoundException($"Answer with ID {id} not found.");
            }
            return answer;
        }

        public Task SaveChangesAsync()
        {
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(Answer entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Answers.Update(entity);
        }
    }
}
