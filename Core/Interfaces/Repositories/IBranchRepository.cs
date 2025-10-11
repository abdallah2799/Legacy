using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task<Branch?> GetByManagerIdAsync(int managerId);
        Task<IEnumerable<Branch>> GetBranchesWithTracksAsync();
    }
}
