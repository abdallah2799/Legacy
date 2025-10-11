using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
namespace Core.Interfaces.Repositories
{
    public interface IInstructorRepository : IGenericRepository<Instructor>
    {
        Task<IEnumerable<Course>> GetAssignedCoursesAsync(int instructorId);
        Task<IEnumerable<Exam>> GetCreatedExamsAsync(int instructorId);
        Task<IEnumerable<Question>> GetCreatedQuestionsAsync(int instructorId);
        Task<Branch?> GetAssignedBranchAsync(int instructorId);

        Task<IEnumerable<Track>> GetSupervisedTracksAsync(int instructorId);

        Task<Branch> GetManagedBranchAsync(int instructorId);

        /// <summary>
        /// Gets an instructor with all related data: Branch, Courses, Exams, Questions, Supervised Tracks, etc.
        /// </summary>
        Task<Instructor?> GetFullDataAsync(int instructorId);
    }
}
