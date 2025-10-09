using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IApplicantRepository : IGenericRepository<Applicant>
    {
        Task<IEnumerable<Applicant>> GetPendingApplicationsAsync();
        Task<IEnumerable<Applicant>> GetByStatusAsync(string status);
    }
}
