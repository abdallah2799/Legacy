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
    public class StudentExamRepository : IStudentExamRepository
    {
        private readonly LegacyDbContext _context;

        public StudentExamRepository(LegacyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(StudentExam entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.StudentExams.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var studentExam = await _context.StudentExams.FindAsync(id);
            if (studentExam == null)
                throw new InvalidOperationException($"StudentExam with ID {id} not found.");

            _context.StudentExams.Remove(studentExam);
        }

        public async Task DeleteAsync(StudentExam entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.StudentExams.Remove(entity);
        }

        public async Task<IEnumerable<StudentExam>> FindAsync(Expression<Func<StudentExam, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await _context.StudentExams.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<StudentExam>> GetAllAsync()
        {
            return await _context.StudentExams.ToListAsync();
        }

        public async Task<StudentExam> GetByIdAsync(int id)
        {
            var studentExam = await _context.StudentExams.FindAsync(id);
            if (studentExam == null)
                throw new InvalidOperationException($"StudentExam with ID {id} not found.");
            return studentExam;
        }

        public async Task<IEnumerable<StudentExam>> GetByStudentAsync(int studentId)
        {
            return await _context.StudentExams
                .Where(se => se.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<StudentExam?> GetWithAnswersAsync(int studentExamId)
        {
            return await _context.StudentExams
                .Include(se => se.StudentAnswers)
                    .ThenInclude(sa => sa.Question)
                        .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(se => se.StudentExamId == studentExamId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StudentExam entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.StudentExams.Update(entity);
        }

        public async Task<int> CallCalculateScoreAsync(int studentExamId)
        {
            var result = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_CalculateStudentExamScore @StudentExamId = {0}", 
                studentExamId);
            
            // Get the calculated score from the StudentExam record
            var studentExam = await _context.StudentExams.FindAsync(studentExamId);
            return studentExam?.Score ?? 0;
        }
    }
}