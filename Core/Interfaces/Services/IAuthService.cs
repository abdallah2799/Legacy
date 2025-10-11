using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<User?> AuthenticateAsync(string loginOption, string password);
        Task<string> HashPasswordAsync(string password);
        Task<bool> VerifyPasswordAsync(string hash, string password);
    }
}
