using Core.Interfaces.Services;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ExamNotificationService
    {
        private readonly LegacyDbContext _context;
        private readonly IEmailService _emailService;

        public ExamNotificationService(LegacyDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // عند إنشاء الامتحان
        public async Task NotifyStudentsOnExamCreatedAsync(int examId)
        {
            var exam = await _context.Exams.FirstOrDefaultAsync(e => e.ExamId == examId);
            if (exam == null) return;

            var trackId = await _context.TrackCourses
                .Where(tc => tc.TrackCourseId == exam.TrackCourseId)
                .Select(tc => tc.TrackId)
                .FirstOrDefaultAsync();

            var students = await _context.Students
                .Where(u => u.TrackId == trackId && u.Email != null)
                .ToListAsync();

            foreach (var s in students)
            {
                await _emailService.SendEmailAsync(
                    s.Email,
                    $"New Exam: {exam.Title}",
                    $"Dear {s.FullName},\nA new exam \"{exam.Title}\" is scheduled on {exam.ScheduledAt:dddd, dd MMM yyyy HH:mm}."
                );
            }
        }

        // قبل الامتحان بيوم
        public async Task NotifyStudentsOneDayBeforeExamAsync()
        {
            var tomorrow = DateTime.Now.AddDays(1).Date;

            var exams = await _context.Exams
                .Where(e => e.ScheduledAt.HasValue && e.ScheduledAt.Value.Date == tomorrow)
                .ToListAsync();

            foreach (var exam in exams)
            {
                var trackId = await _context.TrackCourses
                    .Where(tc => tc.TrackCourseId == exam.TrackCourseId)
                    .Select(tc => tc.TrackId)
                    .FirstOrDefaultAsync();

                var students = await _context.Students
                    .Where(u => u.TrackId == trackId && u.Email != null)
                    .ToListAsync();

                foreach (var s in students)
                {
                    await _emailService.SendEmailAsync(
                        s.Email,
                        $"Reminder: Exam Tomorrow - {exam.Title}",
                        $"Dear {s.FullName},\nYou have an exam \"{exam.Title}\" scheduled tomorrow at {exam.ScheduledAt:HH:mm}."
                    );
                }
            }
        }
    }
}
