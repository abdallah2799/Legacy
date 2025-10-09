using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IBranchService
    {
        Task<IEnumerable<Branch>> GetAllBranchesAsync();
        Task AssignManagerAsync(int branchId, int managerId);
        Task<IEnumerable<Branch>> GetBranchesWithTracksAsync();
    }
}
