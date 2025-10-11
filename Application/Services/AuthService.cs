using Common.Helpers;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AuthService> _logger;

        // The constructor is now clean again.
        public AuthService(IUserRepository userRepository, ILogger<AuthService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<User?> AuthenticateAsync(string loginOption, string password)
        {
            try
            {
                var users = await _userRepository.FindAsync(u =>
                    u.Username == loginOption || u.Email == loginOption);

                var user = users.FirstOrDefault();
                if (user == null)
                {
                    _logger.LogWarning("Authentication failed: User not found for {LoginOption}", loginOption);
                    return null;
                }

                // --- THIS IS THE CORRECTED, SECURE LOGIC ---
                // Re-enable the password verification
                if (!PasswordHelper.VerifyPassword(user.PasswordHash, password))
                {
                    _logger.LogWarning("Authentication failed: Invalid password for user {UserId}", user.UserId);
                    return null;
                }
                // ---------------------------------------------

                _logger.LogInformation("User authenticated successfully: {UserId}", user.UserId);

                if (user.Role == "Student")
                {
                    return await _userRepository.GetStudentByIdAsync(user.UserId);
                }

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during authentication for {LoginOption}", loginOption);
                return null;
            }
        }

        public Task<string> HashPasswordAsync(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null or empty", nameof(password));
            }
            return Task.FromResult(PasswordHelper.HashPassword(password));
        }

        public Task<bool> VerifyPasswordAsync(string hash, string password)
        {
            if (string.IsNullOrWhiteSpace(hash) || string.IsNullOrWhiteSpace(password))
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(PasswordHelper.VerifyPassword(hash, password));
        }
    }
}