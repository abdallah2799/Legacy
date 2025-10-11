using Core.Models;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task AddCourseAsync(Course course)
        {
            await _courseRepository.AddAsync(course);
            await _courseRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetByTrackAsync(int trackId)
        {
            return await _courseRepository.GetByTrackAsync(trackId);
        }

        public async Task<IEnumerable<Course>> FindAsync(System.Linq.Expressions.Expression<System.Func<Course, bool>> predicate)
        {
            var courses = await _courseRepository.FindAsync(predicate);
            return courses;
        }


    }
}
