using Core.Interfaces.Services;
using Core.Interfaces.Repositories;
using Core.Models;
using Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly ICacheService _cacheService;
        private readonly ILogger<UserService> _logger;

        public UserService(
            IUserRepository userRepository,
            IAuthService authService,
            ICacheService cacheService,
            ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _authService = authService;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<User?> GetProfileAsync(int userId)
        {
            try
            {
                var cacheKey = Constants.CacheKeys.UserProfile(userId);
                var cachedUser = await _cacheService.GetAsync<User>(cacheKey);
                
                if (cachedUser != null)
                {
                    _logger.LogDebug("User profile retrieved from cache for user ID: {UserId}", userId);
                    return cachedUser;
                }

                var user = await _userRepository.GetByIdAsync(userId);
                if (user != null)
                {
                    await _cacheService.SetAsync(cacheKey, user, Constants.Defaults.CACHE_USERS_EXPIRATION);
                }

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user profile for user ID: {UserId}", userId);
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                var cacheKey = Constants.CacheKeys.USERS;
                return await _cacheService.GetOrCreateAsync(
                    cacheKey,
                    async () => (await _userRepository.GetAllAsync()).ToList(),
                    Constants.Defaults.CACHE_USERS_EXPIRATION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all users");
                throw;
            }
        }

        public async Task RegisterAsync(User user, string password)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    throw new ArgumentException("Password cannot be null or empty", nameof(password));
                }

                // Check if username or email already exists
                var existingUsers = await _userRepository.FindAsync(u => 
                    u.Username == user.Username || u.Email == user.Email);

                if (existingUsers.Any())
                {
                    throw new InvalidOperationException("User with this username or email already exists");
                }

                // Hash password
                user.PasswordHash = await _authService.HashPasswordAsync(password);
                user.CreatedAt = DateTime.UtcNow;
                user.UpdatedAt = DateTime.UtcNow;

                await _userRepository.AddAsync(user);
                await _userRepository.SaveChangesAsync();

                // Clear users cache
                await _cacheService.RemoveAsync(Constants.CacheKeys.USERS);

                _logger.LogInformation("User registered successfully: {UserId}", user.UserId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering user with username: {Username}", user.Username);
                throw;
            }
        }

        public async Task AssignRoleAsync(int userId, string role)
        {
            try
            {
                if (!Enum.TryParse<Common.Enums.UserRoleEnum>(role, true, out var roleEnum))
                {
                    throw new ArgumentException($"Invalid role: {role}", nameof(role));
                }

                var user = await _userRepository.GetByIdAsync(userId);
                if (user == null)
                {
                    throw new InvalidOperationException($"User with ID {userId} not found");
                }

                user.RoleEnum = roleEnum;
                user.UpdatedAt = DateTime.UtcNow;

                await _userRepository.UpdateAsync(user);
                await _userRepository.SaveChangesAsync();

                // Clear user-specific cache
                await _cacheService.RemoveAsync(Constants.CacheKeys.UserProfile(userId));
                await _cacheService.RemoveAsync(Constants.CacheKeys.USERS);

                _logger.LogInformation("Role assigned to user: {UserId}, Role: {Role}", userId, role);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning role to user ID: {UserId}", userId);
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role)
        {
            try
            {
                if (!Enum.TryParse<Common.Enums.UserRoleEnum>(role, true, out _))
                {
                    throw new ArgumentException($"Invalid role: {role}", nameof(role));
                }

                return await _userRepository.FindAsync(u => u.Role == role);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving users by role: {Role}", role);
                throw;
            }
        }
    }
}
