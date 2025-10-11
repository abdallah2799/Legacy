using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<User?> GetProfileAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task RegisterAsync(User user, string password);
        Task AssignRoleAsync(int userId, string role);
        Task<IEnumerable<User>> GetUsersByRoleAsync(string role);
    }
}
