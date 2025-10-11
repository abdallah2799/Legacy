using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ILogService
    {
        Task LogAsync(string level, string message, int? userId = null, Exception? ex = null);
        Task<IEnumerable<Log>> GetLogsByUserAsync(int userId);
    }
}
