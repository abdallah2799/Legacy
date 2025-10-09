using Core.Interfaces.Services;
using Core.Interfaces.Repositories;
using Core.Models;
using Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly ITranslationRepository _translationRepository;
        private readonly ICacheService _cacheService;
        private readonly ILogger<TranslationService> _logger;

        public TranslationService(
            ITranslationRepository translationRepository,
            ICacheService cacheService,
            ILogger<TranslationService> logger)
        {
            _translationRepository = translationRepository;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<Translation> GetByIdAsync(int translationId)
        {
            try
            {
                return await _translationRepository.GetByIdAsync(translationId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving translation with ID: {TranslationId}", translationId);
                throw;
            }
        }

        public async Task<IEnumerable<Translation>> GetByEntityTypeAsync(string entityType)
        {
            try
            {
                return await _translationRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving translations for entity type: {EntityType}", entityType);
                throw;
            }
        }

        public async Task<IEnumerable<Translation>> GetByLanguageAsync(string languageCode)
        {
            try
            {
                var cacheKey = $"{Constants.CacheKeys.TRANSLATIONS}_{languageCode}";
                return await _cacheService.GetOrCreateAsync(
                    cacheKey,
                    async () => (await _translationRepository.GetAllAsync()).ToList(),
                    Constants.Defaults.CACHE_TRACKS_EXPIRATION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving translations for language: {LanguageCode}", languageCode);
                throw;
            }
        }

        public async Task AddAsync(Translation translation)
        {
            try
            {
                if (translation == null)
                {
                    throw new ArgumentNullException(nameof(translation));
                }

                // Translation model doesn't have CreatedAt/UpdatedAt properties

                await _translationRepository.AddAsync(translation);
                await _translationRepository.SaveChangesAsync();

                // Clear cache
                await _cacheService.RemoveAsync($"{Constants.CacheKeys.TRANSLATIONS}_{translation.LanguageCode}");

                _logger.LogInformation("Translation added successfully: {TranslationId}", translation.TranslationId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding translation");
                throw;
            }
        }

        public async Task UpdateAsync(Translation translation)
        {
            try
            {
                if (translation == null)
                {
                    throw new ArgumentNullException(nameof(translation));
                }

                // Translation model doesn't have UpdatedAt property

                await _translationRepository.UpdateAsync(translation);
                await _translationRepository.SaveChangesAsync();

                // Clear cache
                await _cacheService.RemoveAsync($"{Constants.CacheKeys.TRANSLATIONS}_{translation.LanguageCode}");

                _logger.LogInformation("Translation updated successfully: {TranslationId}", translation.TranslationId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating translation: {TranslationId}", translation.TranslationId);
                throw;
            }
        }

        public async Task DeleteAsync(int translationId)
        {
            try
            {
                var translation = await _translationRepository.GetByIdAsync(translationId);
                await _translationRepository.DeleteAsync(translationId);
                await _translationRepository.SaveChangesAsync();

                // Clear cache
                if (translation != null)
                {
                    await _cacheService.RemoveAsync($"{Constants.CacheKeys.TRANSLATIONS}_{translation.LanguageCode}");
                }

                _logger.LogInformation("Translation deleted successfully: {TranslationId}", translationId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting translation: {TranslationId}", translationId);
                throw;
            }
        }

        public async Task<IEnumerable<Translation>> GetByEntityAsync(string entityName, int entityId)
        {
            try
            {
                return await _translationRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving translations for entity: {EntityName} ID: {EntityId}", entityName, entityId);
                throw;
            }
        }

        public async Task AddTranslationAsync(Translation translation)
        {
            try
            {
                await AddAsync(translation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding translation");
                throw;
            }
        }

        public async Task<string> GetTranslatedTextAsync(string entityType, int entityId, string fieldName, string languageCode, string defaultText = "")
        {
            try
            {
                var translations = await GetByLanguageAsync(languageCode);
                var translation = translations.FirstOrDefault(t => 
                    t.EntityName == entityType && 
                    t.EntityId == entityId && 
                    t.FieldName == fieldName);

                return translation?.TranslatedText ?? defaultText;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting translated text for {EntityType}:{EntityId}.{FieldName} in {LanguageCode}", 
                    entityType, entityId, fieldName, languageCode);
                return defaultText;
            }
        }
    }
}
