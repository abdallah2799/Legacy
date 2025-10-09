using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IBranchTrackService
    {
        Task<BranchTrack> GetByIdAsync(int branchTrackId);
        Task<IEnumerable<BranchTrack>> GetAllAsync();
        Task AddAsync(BranchTrack branchTrack);
        Task UpdateAsync(BranchTrack branchTrack);
        Task DeleteAsync(int branchTrackId);
    }
}