using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ILogRepository : IGenericRepository<Log>
    {
        Task<IEnumerable<Log>> GetLogsByUserAsync(int userId);
        Task<IEnumerable<Log>> GetByDateRangeAsync(DateTime from, DateTime to);
    }
}
