using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ICoursePolicyService
    {
        Task<IEnumerable<CoursePolicy>> GetActivePoliciesAsync();
        Task<CoursePolicy?> GetByTrackCourseAsync(int trackCourseId);
        Task AddOrUpdatePolicyAsync(CoursePolicy policy);
    }
}
