using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ICoursePolicyRepository : IGenericRepository<CoursePolicy>
    {
        Task<IEnumerable<CoursePolicy>> GetActivePoliciesAsync();
        Task<CoursePolicy?> GetByTrackCourseAsync(int trackCourseId);
    }
}
