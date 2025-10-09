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
    public class TrackRepository : ITrackRepository
    {
        private readonly LegacyDbContext _context;

        public TrackRepository(LegacyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Track entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Tracks.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track == null)
                throw new InvalidOperationException($"Track with ID {id} not found.");

            _context.Tracks.Remove(track);
        }

        public async Task DeleteAsync(Track entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Tracks.Remove(entity);
        }

        public async Task<IEnumerable<Track>> FindAsync(Expression<Func<Track, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await _context.Tracks.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Track>> GetAllAsync()
        {
            return await _context.Tracks.ToListAsync();
        }

        public async Task<Track> GetByIdAsync(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track == null)
                throw new InvalidOperationException($"Track with ID {id} not found.");
            return track;
        }

        public async Task<IEnumerable<Track>> GetWithCoursesAsync()
        {
            return await _context.Tracks
                .Include(t => t.TrackCourses)
                    .ThenInclude(tc => tc.Course)
                .ToListAsync();
        }

        public async Task<IEnumerable<Track>> GetWithSupervisorsAsync()
        {
            return await _context.Tracks
                .Include(t => t.BranchTracks)
                    .ThenInclude(bt => bt.Branch)
                .Include(t => t.BranchTracks)
                    .ThenInclude(bt => bt.Supervisor)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Track entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Tracks.Update(entity);
        }
    }
}