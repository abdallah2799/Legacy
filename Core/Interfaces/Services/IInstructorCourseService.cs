using Core.Models;

namespace Core.Interfaces.Services
{
    public interface IInstructorCourseService
    {
        Task<IEnumerable<Course>> GetCoursesByInstructorAsync(int instructorId);
        Task<IEnumerable<Instructor>> GetInstructorsByCourseAsync(int courseId);
        Task AssignInstructorToCourseAsync(int instructorId, int courseId);
        Task RemoveInstructorFromCourseAsync(int instructorId, int courseId);
    }
}
