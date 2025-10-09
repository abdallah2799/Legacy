using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task AddCourseAsync(Course course);
        Task<IEnumerable<Course>> GetByTrackAsync(int trackId);
    }
}
