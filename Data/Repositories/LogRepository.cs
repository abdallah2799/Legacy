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
    public class LogRepository : ILogRepository
    {
        private readonly LegacyDbContext _context;

        public LogRepository(LegacyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Log entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Logs.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var log = await _context.Logs.FindAsync(id);
            if (log == null)
                throw new InvalidOperationException($"Log with ID {id} not found.");

            _context.Logs.Remove(log);
        }

        public async Task DeleteAsync(Log entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Logs.Remove(entity);
        }
        public async Task<IEnumerable<Log>> FindAsync(Expression<Func<Log, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await _context.Logs.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Log>> GetAllAsync()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<IEnumerable<Log>> GetByDateRangeAsync(DateTime from, DateTime to)
        {
            if (from > to)
                throw new ArgumentException("Start date must be less than or equal to end date.", nameof(from));

            return await _context.Logs
                .Where(log => log.Timestamp >= from && log.Timestamp <= to)
                .ToListAsync();
        }

        public async Task<Log> GetByIdAsync(int id)
        {
            var log = await _context.Logs.FindAsync(id);
            if (log == null)
                throw new InvalidOperationException($"Log with ID {id} not found.");
            return log;
        }

        public async Task<IEnumerable<Log>> GetLogsByUserAsync(int userId)
        {
            return await _context.Logs
                .Where(log => log.UserId == userId)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Log entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Logs.Update(entity);
        }
    }
}