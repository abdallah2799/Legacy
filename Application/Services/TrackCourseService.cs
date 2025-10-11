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
    public class TrackCourseService : ITrackCourseService
    {
        private readonly ITrackCourseRepository _trackCourseRepository;
        private readonly ICacheService _cacheService;
        private readonly ILogger<TrackCourseService> _logger;

        public TrackCourseService(
            ITrackCourseRepository trackCourseRepository,
            ICacheService cacheService,
            ILogger<TrackCourseService> logger)
        {
            _trackCourseRepository = trackCourseRepository;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<IEnumerable<TrackCourse>> GetByTrackAsync(int trackId)
        {
            try
            {
                var cacheKey = Constants.CacheKeys.TrackCourses(trackId);
                return await _cacheService.GetOrCreateAsync(
                    cacheKey,
                    async () => (await _trackCourseRepository.GetByTrackIdAsync(trackId)).ToList(),
                    Constants.Defaults.CACHE_TRACKS_EXPIRATION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving TrackCourses for track ID: {TrackId}", trackId);
                throw;
            }
        }

        public async Task<TrackCourse> GetByIdAsync(int trackCourseId)
        {
            try
            {
                return await _trackCourseRepository.GetByIdAsync(trackCourseId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving TrackCourse with ID: {TrackCourseId}", trackCourseId);
                throw;
            }
        }

        public async Task AddAsync(TrackCourse trackCourse)
        {
            try
            {
                await _trackCourseRepository.AddAsync(trackCourse);
                await _trackCourseRepository.SaveChangesAsync();
                
                // Clear cache
                await _cacheService.RemoveAsync(Constants.CacheKeys.TrackCourses(trackCourse.TrackId));
                
                _logger.LogInformation("TrackCourse added successfully: {TrackCourseId}", trackCourse.TrackCourseId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding TrackCourse");
                throw;
            }
        }

        public async Task UpdateAsync(TrackCourse trackCourse)
        {
            try
            {
                await _trackCourseRepository.UpdateAsync(trackCourse);
                await _trackCourseRepository.SaveChangesAsync();
                
                // Clear cache
                await _cacheService.RemoveAsync(Constants.CacheKeys.TrackCourses(trackCourse.TrackId));
                
                _logger.LogInformation("TrackCourse updated successfully: {TrackCourseId}", trackCourse.TrackCourseId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating TrackCourse: {TrackCourseId}", trackCourse.TrackCourseId);
                throw;
            }
        }

        public async Task DeleteAsync(int trackCourseId)
        {
            try
            {
                var trackCourse = await _trackCourseRepository.GetByIdAsync(trackCourseId);
                await _trackCourseRepository.DeleteAsync(trackCourseId);
                await _trackCourseRepository.SaveChangesAsync();
                
                // Clear cache
                if (trackCourse != null)
                {
                    await _cacheService.RemoveAsync(Constants.CacheKeys.TrackCourses(trackCourse.TrackId));
                }
                
                _logger.LogInformation("TrackCourse deleted successfully: {TrackCourseId}", trackCourseId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting TrackCourse: {TrackCourseId}", trackCourseId);
                throw;
            }
        }
    }
}
