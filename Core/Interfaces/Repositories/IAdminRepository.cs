using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces.Repositories
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        /// <summary>
        /// Gets all pending applicants
        /// </summary>
        Task<IEnumerable<Applicant>> GetPendingApplicantsAsync();

        /// <summary>
        /// Gets all logs (optionally filtered by level or date)
        /// </summary>
        Task<IEnumerable<Log>> GetSystemLogsAsync();

        /// <summary>
        /// Gets all users by role (e.g., list all instructors or students)
        /// </summary>
        Task<IEnumerable<User>> GetUsersByRoleAsync(string role);

        /// <summary>
        /// Gets translation entries for management
        /// </summary>
        Task<IEnumerable<Translation>> GetAllTranslationsAsync();
    }
}
