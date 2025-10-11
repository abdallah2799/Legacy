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
    public class CoursePolicyService : ICoursePolicyService
    {
        private readonly ICoursePolicyRepository _coursePolicyRepository;
        private readonly ICacheService _cacheService;
        private readonly ILogger<CoursePolicyService> _logger;

        public CoursePolicyService(
            ICoursePolicyRepository coursePolicyRepository,
            ICacheService cacheService,
            ILogger<CoursePolicyService> logger)
        {
            _coursePolicyRepository = coursePolicyRepository;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<IEnumerable<CoursePolicy>> GetActivePoliciesAsync()
        {
            try
            {
                var cacheKey = Constants.CacheKeys.COURSE_POLICIES;
                return await _cacheService.GetOrCreateAsync(
                    cacheKey,
                    async () => (await _coursePolicyRepository.GetAllAsync()).ToList(),
                    Constants.Defaults.CACHE_COURSES_EXPIRATION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving active course policies");
                throw;
            }
        }

        public async Task<CoursePolicy?> GetByTrackCourseAsync(int trackCourseId)
        {
            try
            {
                return await _coursePolicyRepository.GetByTrackCourseAsync(trackCourseId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving course policy for TrackCourse ID: {TrackCourseId}", trackCourseId);
                throw;
            }
        }

        public async Task AddOrUpdatePolicyAsync(CoursePolicy policy)
        {
            try
            {
                if (policy == null)
                {
                    throw new ArgumentNullException(nameof(policy));
                }

                var existingPolicy = await _coursePolicyRepository.GetByTrackCourseAsync(policy.TrackCourseId);
                
                if (existingPolicy != null)
                {
                    existingPolicy.PassPercentage = policy.PassPercentage;
                    existingPolicy.EffectiveFrom = policy.EffectiveFrom;
                    existingPolicy.EffectiveTo = policy.EffectiveTo;
                    existingPolicy.ManagedBy = policy.ManagedBy;
                    
                    await _coursePolicyRepository.UpdateAsync(existingPolicy);
                }
                else
                {
                    await _coursePolicyRepository.AddAsync(policy);
                }

                await _coursePolicyRepository.SaveChangesAsync();
                await _cacheService.RemoveAsync(Constants.CacheKeys.COURSE_POLICIES);

                _logger.LogInformation("Course policy updated for TrackCourse ID: {TrackCourseId}", policy.TrackCourseId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding/updating course policy for TrackCourse ID: {TrackCourseId}", policy.TrackCourseId);
                throw;
            }
        }
    }
}
