using Core.Interfaces.Services;
using Core.Interfaces.Repositories;
using Core.Models;
using Common.Enums;
using Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ICoursePolicyRepository _coursePolicyRepository;
        private readonly ICacheService _cacheService;
        private readonly ILogger<ExamService> _logger;

        public ExamService(
            IExamRepository examRepository,
            IQuestionRepository questionRepository,
            ICoursePolicyRepository coursePolicyRepository,
            ICacheService cacheService,
            ILogger<ExamService> logger)
        {
            _examRepository = examRepository;
            _questionRepository = questionRepository;
            _coursePolicyRepository = coursePolicyRepository;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<IEnumerable<Exam>> GetAllExamsAsync()
        {
            try
            {
                return await _examRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all exams");
                throw;
            }
        }

        public async Task<IEnumerable<Exam>> GetActiveExamsAsync()
        {
            try
            {
                var cacheKey = Constants.CacheKeys.ACTIVE_EXAMS;
                return await _cacheService.GetOrCreateAsync(
                    cacheKey,
                    async () => (await _examRepository.FindAsync(e => e.Status == ExamStatusEnum.Started)).ToList(),
                    Constants.Defaults.CACHE_ACTIVE_EXAMS_EXPIRATION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving active exams");
                throw;
            }
        }

        public async Task<Exam?> GetExamWithQuestionsAsync(int examId)
        {
            try
            {
                var exam = await _examRepository.GetByIdAsync(examId);
                if (exam == null)
                {
                    return null;
                }

                // Load questions for the exam
                // Note: This would need to be implemented based on your ExamQuestion relationship
                return exam;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving exam with questions for exam ID: {ExamId}", examId);
                throw;
            }
        }

        public async Task CreateExamAsync(Exam exam)
        {
            try
            {
                if (exam == null)
                {
                    throw new ArgumentNullException(nameof(exam));
                }

                // Validate course policy
                var coursePolicy = await _coursePolicyRepository.GetByTrackCourseAsync(exam.TrackCourseId);
                if (coursePolicy == null)
                {
                    throw new InvalidOperationException($"No course policy found for TrackCourse ID: {exam.TrackCourseId}");
                }

                // Set default values
                exam.CreatedAt = DateTime.UtcNow;
                exam.UpdatedAt = DateTime.UtcNow;
                exam.Status = ExamStatusEnum.Queued;

                // Generate exam from question bank
                await GenerateExamQuestions(exam);

                await _examRepository.AddAsync(exam);
                await _examRepository.SaveChangesAsync();

                // Clear active exams cache
                await _cacheService.RemoveAsync(Constants.CacheKeys.ACTIVE_EXAMS);

                _logger.LogInformation("Exam created successfully: {ExamId} - {Title}", exam.ExamId, exam.Title);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating exam: {Title}", exam.Title);
                throw;
            }
        }

        public async Task UpdateExamStatusAsync(int examId, string status)
        {
            try
            {
                if (!Enum.TryParse<ExamStatusEnum>(status, true, out var examStatus))
                {
                    throw new ArgumentException($"Invalid exam status: {status}", nameof(status));
                }

                var exam = await _examRepository.GetByIdAsync(examId);
                if (exam == null)
                {
                    throw new InvalidOperationException($"Exam with ID {examId} not found");
                }

                exam.Status = examStatus;
                exam.UpdatedAt = DateTime.UtcNow;

                await _examRepository.UpdateAsync(exam);
                await _examRepository.SaveChangesAsync();

                // Clear active exams cache
                await _cacheService.RemoveAsync(Constants.CacheKeys.ACTIVE_EXAMS);

                _logger.LogInformation("Exam status updated: {ExamId} - {Status}", examId, status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating exam status for exam ID: {ExamId}", examId);
                throw;
            }
        }

        private async Task GenerateExamQuestions(Exam exam)
        {
            try
            {
                // This is a simplified implementation
                // In a real scenario, you'd have more sophisticated logic for question selection
                // based on difficulty, topic distribution, etc.

                // Get questions for the course
                var questions = await _questionRepository.GetByCourseAsync(exam.TrackCourseId);
                
                if (!questions.Any())
                {
                    throw new InvalidOperationException($"No questions found for TrackCourse ID: {exam.TrackCourseId}");
                }

                // Simple random selection - you might want to implement more sophisticated logic
                var random = new Random();
                var selectedQuestions = questions.OrderBy(x => random.Next()).Take(10).ToList();

                // Calculate total marks
                exam.FullMark = selectedQuestions.Sum(q => q.Marks);
                exam.PassMark = (int)(exam.FullMark * (Constants.Defaults.DEFAULT_PASS_PERCENTAGE / 100.0));

                _logger.LogInformation("Generated {Count} questions for exam {ExamId}", selectedQuestions.Count, exam.ExamId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating questions for exam {ExamId}", exam.ExamId);
                throw;
            }
        }
    }
}
