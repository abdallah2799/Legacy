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
    public class TrackCourseRepository : ITrackCourseRepository
    {
        private readonly LegacyDbContext _context;

        public TrackCourseRepository(LegacyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TrackCourse entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.TrackCourses.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var trackCourse = await _context.TrackCourses.FindAsync(id);
            if (trackCourse == null)
                throw new InvalidOperationException($"TrackCourse with ID {id} not found.");

            _context.TrackCourses.Remove(trackCourse);
        }

        public async Task DeleteAsync(TrackCourse entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.TrackCourses.Remove(entity);
        }

        public async Task<IEnumerable<TrackCourse>> FindAsync(Expression<Func<TrackCourse, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await _context.TrackCourses.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TrackCourse>> GetAllAsync()
        {
            return await _context.TrackCourses.ToListAsync();
        }

        public async Task<TrackCourse> GetByIdAsync(int id)
        {
            var trackCourse = await _context.TrackCourses.FindAsync(id);
            if (trackCourse == null)
                throw new InvalidOperationException($"TrackCourse with ID {id} not found.");
            return trackCourse;
        }

        public async Task<IEnumerable<TrackCourse>> GetByTrackIdAsync(int trackId)
        {
            return await _context.TrackCourses
                .Where(tc => tc.TrackId == trackId)
                .ToListAsync();
        }

        public async Task<IEnumerable<TrackCourse>> GetDetailedAsync()
        {
            return await _context.TrackCourses
                .Include(tc => tc.Track)
                .Include(tc => tc.Course)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TrackCourse entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.TrackCourses.Update(entity);
        }
    }
}