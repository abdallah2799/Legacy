using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ITrackService
    {
        Task<IEnumerable<Track>> GetAllTracksAsync();
        Task<IEnumerable<Track>> GetWithCoursesAsync();
        Task AssignSupervisorAsync(int trackId, int supervisorId);
    }
}
