using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly LegacyDbContext _context;

        public CourseRepository(LegacyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Course entity)
        {
            await _context.Courses.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
                _context.Courses.Remove(course);
        }

        public async Task DeleteAsync(Course entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Courses.Remove(entity);
        }
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.AsNoTracking().ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses.AsNoTracking().FirstOrDefaultAsync(c => c.CourseId == id);
        }

        public async Task<IEnumerable<Course>> FindAsync(System.Linq.Expressions.Expression<System.Func<Course, bool>> predicate)
        {
            return await _context.Courses.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetByTrackAsync(int trackId)
        {
            return await _context.TrackCourses
                .Where(tc => tc.TrackId == trackId)
                .Select(tc => tc.Course)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetWithInstructorsAsync()
        {
            return await _context.Courses
                .Include(c => c.InstructorCourses)
                .ThenInclude(ic => ic.Instructor)
                .AsNoTracking()
                .ToListAsync();
        }

        public Task UpdateAsync(Course entity)
        {
            _context.Courses.Update(entity);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
