using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ITrackCourseRepository : IGenericRepository<TrackCourse>
    {
        Task<IEnumerable<TrackCourse>> GetDetailedAsync();
        Task<IEnumerable<TrackCourse>> GetByTrackIdAsync(int trackId);
    }
}
