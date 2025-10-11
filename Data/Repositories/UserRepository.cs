using Common.Enums;
using Common.Helpers;
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
    public class UserRepository : IUserRepository
    {
        private readonly LegacyDbContext _context;

        public UserRepository(LegacyDbContext context)
        {
            _context = context;
        }


        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            // This is the correct way to query a derived type in a TPH setup.
            // It queries the base DbSet (Users) and filters for the Student type.
            return await _context.Users
                .OfType<Student>()
                .FirstOrDefaultAsync(s => s.UserId == id);
        }

        public async Task AddAsync(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Users.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                throw new InvalidOperationException($"User with ID {id} not found.");

            _context.Users.Remove(user);
        }

        public async Task DeleteAsync(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Users.Remove(entity);
        }

        public async Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await _context.Users.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                throw new InvalidOperationException($"User with ID {id} not found.");
            return user;
        }

        public async Task<IEnumerable<User>> GetByRoleAsync(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Role cannot be null or empty.", nameof(role));

            return await _context.Users
                .Where(u => u.Role == role)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByRoleAsync(UserRoleEnum role)
        {
            var roleString = role.ToString();
            return await _context.Users
                .Where(u => u.Role == roleString)
                .ToListAsync();
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetByLoginOptionAndPasswordAsync(string loginOption, string password)
        {
            if (string.IsNullOrWhiteSpace(loginOption) || string.IsNullOrWhiteSpace(password))
                return null;

            var passwordHash = PasswordHelper.HashPassword(password);

            return await _context.Users
                .FirstOrDefaultAsync(u => ( u.Username == loginOption || u.Email == loginOption ) && u.PasswordHash == passwordHash);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Users.Update(entity);
        }
    }
}