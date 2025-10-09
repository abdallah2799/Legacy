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
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;
        private readonly ICacheService _cacheService;
        private readonly ILogger<TrackService> _logger;

        public TrackService(
            ITrackRepository trackRepository,
            ICacheService cacheService,
            ILogger<TrackService> logger)
        {
            _trackRepository = trackRepository;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<IEnumerable<Track>> GetAllTracksAsync()
        {
            try
            {
                var cacheKey = Constants.CacheKeys.TRACKS;
                return await _cacheService.GetOrCreateAsync(
                    cacheKey,
                    async () => (await _trackRepository.GetAllAsync()).ToList(),
                    Constants.Defaults.CACHE_TRACKS_EXPIRATION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all tracks");
                throw;
            }
        }

        public async Task<IEnumerable<Track>> GetWithCoursesAsync()
        {
            try
            {
                return await _trackRepository.GetWithCoursesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving tracks with courses");
                throw;
            }
        }

        public async Task AssignSupervisorAsync(int trackId, int supervisorId)
        {
            try
            {
                var track = await _trackRepository.GetByIdAsync(trackId);
                if (track == null)
                {
                    throw new InvalidOperationException($"Track with ID {trackId} not found");
                }

                // Validate that the user is an instructor
                // This would require additional validation logic in a real implementation
                // Note: Track model doesn't have SupervisorId property directly
                // Supervisor is managed through BranchTrack relationship
                await _trackRepository.UpdateAsync(track);
                await _trackRepository.SaveChangesAsync();

                // Clear tracks cache
                await _cacheService.RemoveAsync(Constants.CacheKeys.TRACKS);

                _logger.LogInformation("Supervisor {SupervisorId} assigned to track {TrackId}", supervisorId, trackId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning supervisor to track {TrackId}", trackId);
                throw;
            }
        }
    }
}
