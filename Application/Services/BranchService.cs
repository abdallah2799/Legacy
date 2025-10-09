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
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly ICacheService _cacheService;
        private readonly ILogger<BranchService> _logger;

        public BranchService(
            IBranchRepository branchRepository,
            ICacheService cacheService,
            ILogger<BranchService> logger)
        {
            _branchRepository = branchRepository;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<IEnumerable<Branch>> GetAllBranchesAsync()
        {
            try
            {
                var cacheKey = Constants.CacheKeys.BRANCHES;
                return await _cacheService.GetOrCreateAsync(
                    cacheKey,
                    async () => (await _branchRepository.GetAllAsync()).ToList(),
                    Constants.Defaults.CACHE_BRANCHES_EXPIRATION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all branches");
                throw;
            }
        }

        public async Task AssignManagerAsync(int branchId, int managerId)
        {
            try
            {
                var branch = await _branchRepository.GetByIdAsync(branchId);
                if (branch == null)
                {
                    throw new InvalidOperationException($"Branch with ID {branchId} not found");
                }

                // Validate that the user is an instructor
                // This would require additional validation logic in a real implementation

                branch.ManagerId = managerId;
                await _branchRepository.UpdateAsync(branch);
                await _branchRepository.SaveChangesAsync();

                // Clear branches cache
                await _cacheService.RemoveAsync(Constants.CacheKeys.BRANCHES);

                _logger.LogInformation("Manager {ManagerId} assigned to branch {BranchId}", managerId, branchId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning manager to branch {BranchId}", branchId);
                throw;
            }
        }

        public async Task<IEnumerable<Branch>> GetBranchesWithTracksAsync()
        {
            try
            {
                return await _branchRepository.GetBranchesWithTracksAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving branches with tracks");
                throw;
            }
        }
    }
}
