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
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly ILogger<AnswerService> _logger;

        public AnswerService(
            IAnswerRepository answerRepository,
            ILogger<AnswerService> logger)
        {
            _answerRepository = answerRepository;
            _logger = logger;
        }

        public async Task<Answer> GetByIdAsync(int answerId)
        {
            try
            {
                return await _answerRepository.GetByIdAsync(answerId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving answer with ID: {AnswerId}", answerId);
                throw;
            }
        }

        public async Task<IEnumerable<Answer>> GetByQuestionAsync(int questionId)
        {
            try
            {
                return await _answerRepository.GetAnswersForQuestionAsync(questionId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving answers for question ID: {QuestionId}", questionId);
                throw;
            }
        }

        public async Task AddAnswerAsync(Answer answer)
        {
            try
            {
                if (answer == null)
                {
                    throw new ArgumentNullException(nameof(answer));
                }

                if (string.IsNullOrWhiteSpace(answer.Body))
                {
                    throw new InvalidOperationException("Answer text cannot be empty");
                }

                await _answerRepository.AddAsync(answer);
                await _answerRepository.SaveChangesAsync();

                _logger.LogInformation("Answer added successfully: {AnswerId} for question {QuestionId}", 
                    answer.AnswerId, answer.QuestionId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding answer for question ID: {QuestionId}", answer.QuestionId);
                throw;
            }
        }

        public async Task UpdateAnswerAsync(Answer answer)
        {
            try
            {
                if (answer == null)
                {
                    throw new ArgumentNullException(nameof(answer));
                }

                if (string.IsNullOrWhiteSpace(answer.Body))
                {
                    throw new InvalidOperationException("Answer text cannot be empty");
                }

                await _answerRepository.UpdateAsync(answer);
                await _answerRepository.SaveChangesAsync();

                _logger.LogInformation("Answer updated successfully: {AnswerId}", answer.AnswerId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating answer with ID: {AnswerId}", answer.AnswerId);
                throw;
            }
        }

        public async Task DeleteAnswerAsync(int answerId)
        {
            try
            {
                await _answerRepository.DeleteAsync(answerId);
                await _answerRepository.SaveChangesAsync();

                _logger.LogInformation("Answer deleted successfully: {AnswerId}", answerId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting answer with ID: {AnswerId}", answerId);
                throw;
            }
        }

        public async Task ValidateQuestionAnswersAsync(int questionId)
        {
            try
            {
                var answers = await _answerRepository.GetAnswersForQuestionAsync(questionId);
                
                if (!answers.Any())
                {
                    throw new InvalidOperationException("Question must have at least one answer");
                }

                var hasCorrectAnswer = answers.Any(a => a.IsCorrect);
                if (!hasCorrectAnswer)
                {
                    throw new InvalidOperationException("Question must have at least one correct answer");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating answers for question ID: {QuestionId}", questionId);
                throw;
            }
        }
    }
}
