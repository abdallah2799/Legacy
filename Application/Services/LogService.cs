using Core.Interfaces.Services;
using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        private readonly ILogger<LogService> _logger;

        public LogService(ILogRepository logRepository, ILogger<LogService> logger)
        {
            _logRepository = logRepository;
            _logger = logger;
        }

        public async Task LogAsync(string level, string message, int? userId = null, Exception? ex = null)
        {
            try
            {
                var log = new Log
                {
                    Level = level,
                    Message = message,
                    UserId = userId,
                    Exception = ex?.ToString(),
                    Timestamp = DateTime.UtcNow
                };

                await _logRepository.AddAsync(log);
                await _logRepository.SaveChangesAsync();

                // Also log to application logger
                LogToApplicationLogger(level, message, userId, ex);
            }
            catch (Exception logEx)
            {
                // Don't let logging errors break the application
                _logger.LogError(logEx, "Failed to log to database: {Message}", message);
            }
        }

        public async Task<IEnumerable<Log>> GetLogsByUserAsync(int userId)
        {
            try
            {
                return await _logRepository.FindAsync(l => l.UserId == userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving logs for user ID: {UserId}", userId);
                throw;
            }
        }

        private void LogToApplicationLogger(string level, string message, int? userId, Exception? ex)
        {
            var logMessage = $"User: {userId ?? 0} - {message}";

            switch (level.ToLower())
            {
                case "info":
                    _logger.LogInformation(logMessage);
                    break;
                case "warning":
                    _logger.LogWarning(logMessage);
                    break;
                case "error":
                    if (ex != null)
                        _logger.LogError(ex, logMessage);
                    else
                        _logger.LogError(logMessage);
                    break;
                case "debug":
                    _logger.LogDebug(logMessage);
                    break;
                default:
                    _logger.LogInformation(logMessage);
                    break;
            }
        }
    }
}
