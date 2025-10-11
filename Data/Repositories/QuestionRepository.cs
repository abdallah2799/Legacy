using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly LegacyDbContext _context;

        public QuestionRepository(LegacyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Question entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Questions.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
                throw new InvalidOperationException($"Question with ID {id} not found.");

            _context.Questions.Remove(question);
        }
        public async Task DeleteAsync(Question entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

             _context.Questions.Remove(entity);
        }

        public async Task<IEnumerable<Question>> FindAsync(Expression<Func<Question, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await _context.Questions.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<IEnumerable<Question>> GetByCourseAsync(int courseId)
        {
            return await _context.Questions
                .Where(q => q.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<IEnumerable<Question>> GetByTypeAsync(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Question type cannot be null or empty.", nameof(type));

            return await _context.Questions
                .Where(q => q.Type == type)
                .ToListAsync();
        }

        public async Task<Question?> GetWithAnswersAsync(int questionId)
        {
            return await _context.Questions
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.QuestionId == questionId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Question entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Questions.Update(entity);
        }
    }
}