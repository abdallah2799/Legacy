using Core.Interfaces.Services;
using Core.Interfaces.Repositories;
using Core.Models;
using Common.Helpers;
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

        public AuthService(IUserRepository userRepository, ILogger<AuthService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<User?> AuthenticateAsync(string loginOption, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(loginOption) || string.IsNullOrWhiteSpace(password))
                {
                    _logger.LogWarning("Authentication attempted with empty credentials");
                    return null;
                }

                // Find user by username or email
                var users = await _userRepository.FindAsync(u => 
                    u.Username == loginOption || u.Email == loginOption);

                var user = users.FirstOrDefault();
                if (user == null)
                {
                    _logger.LogWarning("Authentication failed: User not found for login option: {LoginOption}", loginOption);
                    return null;
                }

                // Verify password
                if (!PasswordHelper.VerifyPassword(user.PasswordHash, password))
                {
                    _logger.LogWarning("Authentication failed: Invalid password for user: {UserId}", user.UserId);
                    return null;
                }

                _logger.LogInformation("User authenticated successfully: {UserId}", user.UserId);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during authentication for login option: {LoginOption}", loginOption);
                return null;
            }
        }

        public async Task<string> HashPasswordAsync(string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    throw new ArgumentException("Password cannot be null or empty", nameof(password));
                }

                return PasswordHelper.HashPassword(password);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error hashing password");
                throw;
            }
        }

        public async Task<bool> VerifyPasswordAsync(string hash, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(hash) || string.IsNullOrWhiteSpace(password))
                {
                    return false;
                }

                return PasswordHelper.VerifyPassword(hash, password);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error verifying password");
                return false;
            }
        }
    }
}
