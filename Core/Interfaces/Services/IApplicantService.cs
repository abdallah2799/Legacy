using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IApplicantService
    {
        Task<IEnumerable<Applicant>> GetPendingApplicationsAsync();
        Task ApproveApplicantAsync(int applicantId);
        Task RejectApplicantAsync(int applicantId);
        Task SubmitApplicationAsync(Applicant applicant);
    }
}
