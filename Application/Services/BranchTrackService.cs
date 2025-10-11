using Core.Interfaces.Services;
using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BranchTrackService : IBranchTrackService
    {
        private readonly IBranchTrackRepository _branchTrackRepository;
        private readonly ILogger<BranchTrackService> _logger;

        public BranchTrackService(IBranchTrackRepository branchTrackRepository, ILogger<BranchTrackService> logger)
        {
            _branchTrackRepository = branchTrackRepository;
            _logger = logger;
        }

        public async Task<BranchTrack> GetByIdAsync(int branchTrackId)
        {
            try
            {
                return await _branchTrackRepository.GetByIdAsync(branchTrackId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving BranchTrack with ID: {BranchTrackId}", branchTrackId);
                throw;
            }
        }

        public async Task<IEnumerable<BranchTrack>> GetAllAsync()
        {
            try
            {
                return await _branchTrackRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all BranchTracks");
                throw;
            }
        }

        public async Task AddAsync(BranchTrack branchTrack)
        {
            try
            {
                await _branchTrackRepository.AddAsync(branchTrack);
                await _branchTrackRepository.SaveChangesAsync();
                _logger.LogInformation("BranchTrack added successfully: {BranchTrackId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding BranchTrack");
                throw;
            }
        }

        public async Task UpdateAsync(BranchTrack branchTrack)
        {
            try
            {
                await _branchTrackRepository.UpdateAsync(branchTrack);
                await _branchTrackRepository.SaveChangesAsync();
                _logger.LogInformation("BranchTrack updated successfully: {BranchTrackId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating BranchTrack: {BranchTrackId}");
                throw;
            }
        }

        public async Task DeleteAsync(int branchTrackId)
        {
            try
            {
                await _branchTrackRepository.DeleteAsync(branchTrackId);
                await _branchTrackRepository.SaveChangesAsync();
                _logger.LogInformation("BranchTrack deleted successfully: {BranchTrackId}", branchTrackId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting BranchTrack: {BranchTrackId}", branchTrackId);
                throw;
            }
        }
    }
}
