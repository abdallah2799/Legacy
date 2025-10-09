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
    public class StudentAnswerRepository : IStudentAnswerRepository
    {
        private readonly LegacyDbContext _context;

        public StudentAnswerRepository(LegacyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(StudentAnswer entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.StudentAnswers.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var answer = await _context.StudentAnswers.FindAsync(id);
            if (answer == null)
                throw new InvalidOperationException($"StudentAnswer with ID {id} not found.");

            _context.StudentAnswers.Remove(answer);
        }

        public async Task DeleteAsync(StudentAnswer entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.StudentAnswers.Remove(entity);
        }

        public async Task<IEnumerable<StudentAnswer>> FindAsync(Expression<Func<StudentAnswer, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await _context.StudentAnswers.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<StudentAnswer>> GetAllAsync()
        {
            return await _context.StudentAnswers.ToListAsync();
        }

        public async Task<IEnumerable<StudentAnswer>> GetAnswersByExamAsync(int examId, int studentId)
        {
            // First, find the StudentExamID that links this student to this exam
            var studentExam = await _context.StudentExams
                .FirstOrDefaultAsync(se => se.StudentId == studentId && se.ExamId == examId);

            if (studentExam == null)
                return Enumerable.Empty<StudentAnswer>();

            return await _context.StudentAnswers
                .Where(sa => sa.StudentExamId == studentExam.StudentExamId)
                .ToListAsync();
        }

        public async Task<StudentAnswer> GetByIdAsync(int id)
        {
            var studentAnswer = await _context.StudentAnswers.FindAsync(id);
            if (studentAnswer == null)
                throw new InvalidOperationException($"StudentAnswer with ID {id} not found.");

            return studentAnswer;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StudentAnswer entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.StudentAnswers.Update(entity);
        }
    }
}