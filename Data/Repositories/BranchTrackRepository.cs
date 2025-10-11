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
    public class BranchTrackRepository : IBranchTrackRepository
    {
        private readonly LegacyDbContext _context;

        public BranchTrackRepository(LegacyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BranchTrack entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.BranchTracks.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var branchTrack = await _context.BranchTracks.FindAsync(id);
            if (branchTrack == null)
                throw new InvalidOperationException($"BranchTrack with ID {id} not found.");

            _context.BranchTracks.Remove(branchTrack);
        }

        public async Task DeleteAsync(BranchTrack entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.BranchTracks.Remove(entity);
        }

        public async Task<IEnumerable<BranchTrack>> FindAsync(Expression<Func<BranchTrack, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await _context.BranchTracks.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<BranchTrack>> GetAllAsync()
        {
            return await _context.BranchTracks.ToListAsync();
        }

        public async Task<BranchTrack> GetByIdAsync(int id)
        {
            var branchTrack = await _context.BranchTracks.FindAsync(id);
            if (branchTrack == null)
                throw new InvalidOperationException($"BranchTrack with ID {id} not found.");
            return branchTrack;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BranchTrack entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.BranchTracks.Update(entity);
        }

        public async Task<IEnumerable<BranchTrack>> GetByBranchAsync(int branchId)
        {
            return await _context.BranchTracks
                .Where(bt => bt.BranchID == branchId)
                .ToListAsync();
        }

        public async Task<IEnumerable<BranchTrack>> GetByTrackAsync(int trackId)
        {
            return await _context.BranchTracks
                .Where(bt => bt.TrackID == trackId)
                .ToListAsync();
        }
    }
}
