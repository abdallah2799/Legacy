using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly LegacyDbContext _context;

        public BranchRepository(LegacyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Branch entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Branches.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
                throw new InvalidOperationException($"Branch with ID {id} not found.");

            _context.Branches.Remove(branch);
        }

        public async Task DeleteAsync(Branch entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Branches.Remove(entity);
        }
        public async Task<IEnumerable<Branch>> FindAsync(Expression<Func<Branch, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await _context.Branches.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Branch>> GetAllAsync()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<IEnumerable<Branch>> GetBranchesWithTracksAsync()
        {
            return await _context.Branches
                .Include(b => b.BranchTracks)
                    .ThenInclude(bt => bt.Track)
                .ToListAsync();
        }

        public async Task<IEnumerable<Branch>> GetBranchesWithInstructorsAsync()
        {
            return await _context.Branches
                .Include(b => b.Instructors)
                .ToListAsync();
        }

        public async Task<IEnumerable<Branch>> GetBranchesWithStudentsAsync()
        {
            return await _context.Branches
                .Include(b => b.Students)
                .ToListAsync();
        }
        public async Task<Branch> GetByIdAsync(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
                throw new InvalidOperationException($"Branch with ID {id} not found.");

            return branch;
        }

        public async Task<Branch?> GetByManagerIdAsync(int managerId)
        {
            return await _context.Branches
                .FirstOrDefaultAsync(b => b.ManagerId == managerId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Branch entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Branches.Update(entity);
        }
    }
}