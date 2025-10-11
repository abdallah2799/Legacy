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
    public class CoursePolicyRepository : ICoursePolicyRepository
    {
        private readonly LegacyDbContext _context;

        public CoursePolicyRepository(LegacyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CoursePolicy entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.CoursePolicies.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var policy = await _context.CoursePolicies.FindAsync(id);
            if (policy == null)
                throw new InvalidOperationException($"CoursePolicy with ID {id} not found.");

            _context.CoursePolicies.Remove(policy);
        }

        public async Task DeleteAsync(CoursePolicy entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.CoursePolicies.Remove(entity);
        }
        public async Task<IEnumerable<CoursePolicy>> FindAsync(Expression<Func<CoursePolicy, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await _context.CoursePolicies.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<CoursePolicy>> GetActivePoliciesAsync()
        {
            var now = DateTime.UtcNow;
            return await _context.CoursePolicies
                .Where(p => p.EffectiveFrom <= now && (p.EffectiveTo == null || p.EffectiveTo >= now))
                .ToListAsync();
        }

        public async Task<IEnumerable<CoursePolicy>> GetAllAsync()
        {
            return await _context.CoursePolicies.ToListAsync();
        }

        public async Task<CoursePolicy> GetByIdAsync(int id)
        {
            var policy = await _context.CoursePolicies.FindAsync(id);
            if (policy == null)
                throw new InvalidOperationException($"CoursePolicy with ID {id} not found.");
            return policy;
        }

        public async Task<CoursePolicy?> GetByTrackCourseAsync(int trackCourseId)
        {
            return await _context.CoursePolicies
                .FirstOrDefaultAsync(p => p.TrackCourseId == trackCourseId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CoursePolicy entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.CoursePolicies.Update(entity);
        }
    }
}