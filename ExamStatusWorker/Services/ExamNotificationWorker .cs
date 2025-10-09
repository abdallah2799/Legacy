using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Application.Services;

namespace ExamStatusWorker.Services
{
    public class ExamNotificationWorker : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<ExamNotificationWorker> _logger;

        public ExamNotificationWorker(IServiceScopeFactory scopeFactory, ILogger<ExamNotificationWorker> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var notificationService = scope.ServiceProvider.GetRequiredService<ExamNotificationService>();

                    await notificationService.NotifyStudentsOneDayBeforeExamAsync();

                    _logger.LogInformation("✅ Email reminders for upcoming exams sent at: {time}", DateTimeOffset.Now);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "❌ Error in ExamNotificationWorker");
                }

                // Sleep 12 hours 
                await Task.Delay(TimeSpan.FromHours(12), stoppingToken);
            }
        }
    }
}
