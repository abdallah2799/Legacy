using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Common.Enums;

namespace Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly LegacyDbContext _context;

        public AdminRepository(LegacyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Admin entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.Admins.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
                throw new InvalidOperationException($"Admin with ID {id} not found.");
            _context.Admins.Remove(admin);
        }

        public async Task DeleteAsync(Admin entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Admins.Remove(entity);
        }

        public async Task<IEnumerable<Admin>> FindAsync(Expression<Func<Admin, bool>> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return await _context.Admins.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<IEnumerable<Translation>> GetAllTranslationsAsync()
        {
            return await _context.Translations.ToListAsync();
        }

        public async Task<Admin> GetByIdAsync(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
                throw new InvalidOperationException($"Admin with ID {id} not found.");
            return admin;
        }

        public async Task<IEnumerable<Applicant>> GetPendingApplicantsAsync()
        {
            return await _context.Applicants
                .Where(a => a.Status == ApplicationStatus.Pending && a.ToBeDeleted == false)
                .ToListAsync();
        }

        public async Task<IEnumerable<Log>> GetSystemLogsAsync()
        {
            return await _context.Logs
                .OrderByDescending(l => l.Timestamp)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Role cannot be null or empty.", nameof(role));

            // Validate against allowed roles (optional but safe)
            var validRoles = new[] { "Admin", "Instructor", "Student" };
            if (!validRoles.Contains(role))
                throw new ArgumentException($"Invalid role: {role}.", nameof(role));

            return await _context.Users
                .Where(u => u.Role == role)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Admin entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Admins.Update(entity);
        }
    }
}