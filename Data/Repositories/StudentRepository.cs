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
    public class StudentRepository : IStudentRepository
    {
        private readonly LegacyDbContext _context;

        public StudentRepository(LegacyDbContext context)
        {
            _context = context;
        }

        

        public async Task AddAsync(Student entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await _context.Students.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(u => u.UserId == id );
            if (student == null)
                throw new InvalidOperationException($"Student with ID {id} not found.");

            _context.Students.Remove(student);
        }

        public async Task DeleteAsync(Student entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _context.Students.Remove(entity);
        }

        public async Task<IEnumerable<Student>> FindAsync(Expression<Func<Student, bool>> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return await _context.Students.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<IEnumerable<StudentAnswer>> GetAnswersForExamAsync(int studentId, int examId)
        {
            var studentExam = await _context.StudentExams
                .FirstOrDefaultAsync(se => se.StudentId == studentId && se.ExamId == examId);

            if (studentExam == null)
                return Enumerable.Empty<StudentAnswer>();

            return await _context.StudentAnswers
                .Where(sa => sa.StudentExamId == studentExam.StudentExamId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetByBranchAsync(int branchId)
        {
            return await _context.Students
                .Where(s => s.BranchId == branchId)
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(u => u.UserId == id);
            if (student == null)
                throw new InvalidOperationException($"Student with ID {id} not found.");
            return student;
        }

        public async Task<IEnumerable<Student>> GetByTrackAsync(int trackId)
        {
            return await _context.Students
                .Where(s => s.TrackId == trackId)
                .ToListAsync();
        }

        public async Task<StudentExam?> GetExamAttemptAsync(int studentId, int examId)
        {
            return await _context.StudentExams
                .Include(se => se.StudentAnswers)
                    .ThenInclude(sa => sa.Question)
                        .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(se => se.StudentId == studentId && se.ExamId == examId);
        }

        public async Task<IEnumerable<Exam>> GetExamsAsync(int studentId)
        {
            var examIds = await _context.StudentExams
                .Where(se => se.StudentId == studentId)
                .Select(se => se.ExamId)
                .ToListAsync();

            return await _context.Exams
                .Where(e => examIds.Contains(e.ExamId))
                .ToListAsync();
        }

        public async Task<Student?> GetFullDataAsync(int studentId)
        {
            return await _context.Students
                .Include(u => u.Track) // if navigation exists
                .Include(u => u.Branch) // if navigation exists
                .Include(u => u.StudentExams)
                    .ThenInclude(se => se.Exam)
                        .ThenInclude(e => e.TrackCourse)
                            .ThenInclude(tc => tc.Course)
                .Include(u => u.StudentExams)
                    .ThenInclude(se => se.StudentAnswers)
                        .ThenInclude(sa => sa.Question)
                            .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(u => u.UserId == studentId && u.Role == "Student");
        }

        public async Task<Track?> GetTrackAsync(int studentId)
        {
            var student = await _context.Students
                .Where(u => u.UserId == studentId && u.Role == "Student")
                .Select(u => u.TrackId)
                .FirstOrDefaultAsync();

            if (student == 0) return null;

            return await _context.Tracks.FindAsync(student);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Students.Update(entity);
        }
        
    }
}