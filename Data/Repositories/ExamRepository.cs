using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Common.Enums;
using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        public ExamRepository(LegacyDbContext context) : base(context)
        {
            // The body of the constructor is now empty.
            // All it needs to do is pass the context to the base class.
        }

        public async Task AddAsync(Exam entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Exams.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
                throw new InvalidOperationException($"Exam with ID {id} not found.");

            _context.Exams.Remove(exam);
        }

        public async Task DeleteAsync(Exam entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Exams.Remove(entity);
        }
        public async Task<IEnumerable<Exam>> FindAsync(Expression<Func<Exam, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await _context.Exams.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Exam>> GetActiveExamsAsync()
        {
            // Based on the CHECK constraint: Status IN ('Queued', 'Started')
            // "Active" typically means not Finished or Cancelled
            return await _context.Exams
                .Where(e => e.Status == ExamStatusEnum.Queued || e.Status == ExamStatusEnum.Started)
                .ToListAsync();
        }

        public async Task<IEnumerable<Exam>> GetAllAsync()
        {
            return await _context.Exams.ToListAsync();
        }

        public async Task<Exam> GetByIdAsync(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
                throw new InvalidOperationException($"Exam with ID {id} not found.");
            return exam;
        }

        public async Task<IEnumerable<Exam>> GetByTrackCourseAsync(int trackCourseId)
        {
            return await _context.Exams
                .Where(e => e.TrackCourseId == trackCourseId)
                .ToListAsync();
        }

        public async Task<Exam?> GetExamWithQuestionsAsync(int examId)
        {
            return await _context.Exams
                .Include(e => e.Questions)
                    .ThenInclude(eq => eq.Question)
                        .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(e => e.ExamId == examId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Exam entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Exams.Update(entity);
        }
    }
}