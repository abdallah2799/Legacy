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
    public class TranslationRepository : ITranslationRepository
    {
        private readonly LegacyDbContext _context;

        public TranslationRepository(LegacyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Translation entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Translations.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var translation = await _context.Translations.FindAsync(id);
            if (translation == null)
                throw new InvalidOperationException($"Translation with ID {id} not found.");

            _context.Translations.Remove(translation);
        }

        public async Task DeleteAsync(Translation entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Translations.Remove(entity);
        }

        public async Task<IEnumerable<Translation>> FindAsync(Expression<Func<Translation, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await _context.Translations.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Translation>> GetAllAsync()
        {
            return await _context.Translations.ToListAsync();
        }

        public async Task<IEnumerable<Translation>> GetByEntityAsync(string entityName, int entityId)
        {
            if (string.IsNullOrWhiteSpace(entityName))
                throw new ArgumentException("Entity name cannot be null or empty.", nameof(entityName));

            return await _context.Translations
                .Where(t => t.EntityName == entityName && t.EntityId == entityId)
                .ToListAsync();
        }

        public async Task<Translation> GetByIdAsync(int id)
        {
            var translation = await _context.Translations.FindAsync(id);
            if (translation == null)
                throw new InvalidOperationException($"Translation with ID {id} not found.");
            return translation;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Translation entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Translations.Update(entity);
        }
    }
}