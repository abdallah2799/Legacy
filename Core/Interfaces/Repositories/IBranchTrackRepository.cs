using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IBranchTrackRepository : IGenericRepository<BranchTrack>
    {
        Task<IEnumerable<BranchTrack>> GetByBranchAsync(int branchId);
        Task<IEnumerable<BranchTrack>> GetByTrackAsync(int trackId);
    }
}
