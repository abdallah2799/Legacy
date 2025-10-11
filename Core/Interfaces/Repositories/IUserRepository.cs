using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetByRoleAsync(string role);

        // --- ADD THIS NEW METHOD ---
        // This will correctly fetch the full Student object from the Users table.
        Task<Student?> GetStudentByIdAsync(int id);

    }
}
