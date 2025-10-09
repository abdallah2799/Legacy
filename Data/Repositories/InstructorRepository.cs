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
    public class InstructorRepository : IInstructorRepository
    {
        private readonly LegacyDbContext _context;

        public InstructorRepository(LegacyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Instructor entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.Instructors.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
                throw new InvalidOperationException($"Instructor with ID {id} not found.");
            _context.Instructors.Remove(instructor);
        }

        public async Task DeleteAsync(Instructor entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Instructors.Remove(entity);
        }

        public async Task<IEnumerable<Instructor>> FindAsync(Expression<Func<Instructor, bool>> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return await _context.Instructors.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Instructor>> GetAllAsync()
        {
            return await _context.Instructors.ToListAsync();
        }

        public async Task<Branch?> GetAssignedBranchAsync(int instructorId)
        {
            var branchId = await _context.Instructors
                .Where(i => i.UserId == instructorId)
                .Select(i => i.BranchId)
                .FirstOrDefaultAsync();

            if (branchId==0) return null;
            return await _context.Branches.FindAsync(branchId);
        }

        public async Task<IEnumerable<Course>> GetAssignedCoursesAsync(int instructorId)
        {
            var courseIds = await _context.InstructorCourses
                .Where(ic => ic.InstructorId == instructorId)
                .Select(ic => ic.CourseId)
                .ToListAsync();

            return await _context.Courses
                .Where(c => courseIds.Contains(c.CourseId))
                .ToListAsync();
        }

        public async Task<Instructor> GetByIdAsync(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
                throw new InvalidOperationException($"Instructor with ID {id} not found.");
            return instructor;
        }

        public async Task<IEnumerable<Exam>> GetCreatedExamsAsync(int instructorId)
        {
            return await _context.Exams
                .Where(e => e.CreatedBy == instructorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Question>> GetCreatedQuestionsAsync(int instructorId)
        {
            return await _context.Questions
                .Where(q => q.CreatedBy == instructorId)
                .ToListAsync();
        }

        public async Task<Instructor?> GetFullDataAsync(int instructorId)
        {
            return await _context.Instructors
                .Include(i => i.Branch)
                .Include(i => i.InstructorCourses)
                    .ThenInclude(ic => ic.Course)
                .Include(i => i.ManagedBranch)
                .FirstOrDefaultAsync(i => i.UserId == instructorId);
        }

        public async Task<Branch> GetManagedBranchAsync(int instructorId)
        {
            var branch = await _context.Branches
                .FirstOrDefaultAsync(b => b.ManagerId == instructorId);

            if (branch == null)
                throw new InvalidOperationException($"No branch is managed by instructor with ID {instructorId}.");
            return branch;
        }

        public async Task<IEnumerable<Track>> GetSupervisedTracksAsync(int instructorId)
        {
            var trackIds = await _context.BranchTracks
                .Where(bt => bt.SupervisorID == instructorId)
                .Select(bt => bt.TrackID)
                .Distinct()
                .ToListAsync();

            return await _context.Tracks
                .Where(t => trackIds.Contains(t.TrackId))
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Instructor entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Instructors.Update(entity);
        }
    }
}