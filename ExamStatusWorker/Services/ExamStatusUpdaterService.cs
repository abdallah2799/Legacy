using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExamStatusWorker.Services;

public class ExamStatusUpdaterService : BackgroundService
{
private readonly IServiceProvider _serviceProvider;
private readonly ILogger<ExamStatusUpdaterService> _logger;
private readonly TimeSpan _delay = TimeSpan.FromSeconds(60); // تشغل كل دقيقة

public ExamStatusUpdaterService(IServiceProvider serviceProvider, ILogger<ExamStatusUpdaterService> logger)
{
    _serviceProvider = serviceProvider;
    _logger = logger;
}

protected override async Task ExecuteAsync(CancellationToken stoppingToken)
{
    _logger.LogInformation("ExamStatusUpdaterService started.");

    while (!stoppingToken.IsCancellationRequested)
    {
        try
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<LegacyDbContext>();

                // 1) Start exams: Queued && ScheduledAt <= now && not Cancelled
                var now = DateTime.UtcNow; // use UTC consistently (or use local if that's your convention)
                // Use raw SQL update for best performance and atomicity
                await db.Database.ExecuteSqlRawAsync(@"
                        UPDATE Exams
                        SET Status = {0}
                        WHERE Status = {1}
                          AND ScheduledAt <= {2}
                          AND Status != {3};
                    ", parameters: new object[] { "Started", "Queued", now, "Cancelled" });

                // 2) Finish exams: Started && ScheduledAt + Duration <= now
                await db.Database.ExecuteSqlRawAsync(@"
                        UPDATE Exams
                        SET Status = {0}
                        WHERE Status = {1}
                          AND DATEADD(MINUTE, DurationMinutes, ScheduledAt) <= {2}
                          AND Status != {3};
                    ", parameters: new object[] { "Finished", "Started", now, "Cancelled" });

                // Optional: write logs to DB (ExamEventsLog) or to console
                _logger.LogInformation("Exam statuses updated at {time}.", DateTime.UtcNow);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while updating exam statuses.");
        }

        await Task.Delay(_delay, stoppingToken);
    }
}
}