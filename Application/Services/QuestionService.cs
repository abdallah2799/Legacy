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
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ICacheService _cacheService;
        private readonly ILogger<QuestionService> _logger;

        public QuestionService(
            IQuestionRepository questionRepository,
            ICacheService cacheService,
            ILogger<QuestionService> logger)
        {
            _questionRepository = questionRepository;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<IEnumerable<Question>> GetByCourseAsync(int courseId)
        {
            try
            {
                var cacheKey = Constants.CacheKeys.CourseQuestions(courseId);
                return await _cacheService.GetOrCreateAsync(
                    cacheKey,
                    async () => (await _questionRepository.GetByCourseAsync(courseId)).ToList(),
                    Constants.Defaults.CACHE_COURSES_EXPIRATION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving questions for course ID: {CourseId}", courseId);
                throw;
            }
        }

        public async Task AddQuestionAsync(Question question)
        {
            try
            {
                if (question == null)
                {
                    throw new ArgumentNullException(nameof(question));
                }

                // Validate question has answers
                if (!question.Answers.Any())
                {
                    throw new InvalidOperationException("Question must have at least one answer");
                }

                // Validate at least one correct answer
                var hasCorrectAnswer = question.Answers.Any(a => a.IsCorrect);
                if (!hasCorrectAnswer)
                {
                    throw new InvalidOperationException("Question must have at least one correct answer");
                }

                // Validate marks
                if (question.Marks <= 0)
                {
                    throw new InvalidOperationException("Question marks must be greater than 0");
                }

                // Set creation timestamp
                // Question model doesn't have CreatedAt/UpdatedAt properties

                await _questionRepository.AddAsync(question);
                await _questionRepository.SaveChangesAsync();

                // Clear course questions cache
                await _cacheService.RemoveAsync(Constants.CacheKeys.CourseQuestions(question.CourseId));

                _logger.LogInformation("Question added successfully: {QuestionId} for course {CourseId}", 
                    question.QuestionId, question.CourseId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding question for course ID: {CourseId}", question.CourseId);
                throw;
            }
        }

        public async Task<Question?> GetWithAnswersAsync(int questionId)
        {
            try
            {
                return await _questionRepository.GetWithAnswersAsync(questionId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving question with answers for question ID: {QuestionId}", questionId);
                throw;
            }
        }
    }
}
