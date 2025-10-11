using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ITrackRepository : IGenericRepository<Track>
    {
        Task<IEnumerable<Track>> GetWithCoursesAsync();
        Task<IEnumerable<Track>> GetWithSupervisorsAsync();
    }
}
