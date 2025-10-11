using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ITrackCourseService
    {
        Task<IEnumerable<TrackCourse>> GetByTrackAsync(int trackId);
        Task<TrackCourse> GetByIdAsync(int trackCourseId);
        Task AddAsync(TrackCourse trackCourse);
        Task UpdateAsync(TrackCourse trackCourse);
        Task DeleteAsync(int trackCourseId);
    }
}