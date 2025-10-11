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
    public class StudentAnswerService : IStudentAnswerService
    {
        private readonly IStudentAnswerRepository _studentAnswerRepository;
        private readonly IStudentExamRepository _studentExamRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly ILogger<StudentAnswerService> _logger;

        public StudentAnswerService(
            IStudentAnswerRepository studentAnswerRepository,
            IStudentExamRepository studentExamRepository,
            IQuestionRepository questionRepository,
            IAnswerRepository answerRepository,
            ILogger<StudentAnswerService> logger)
        {
            _studentAnswerRepository = studentAnswerRepository;
            _studentExamRepository = studentExamRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _logger = logger;
        }

        public async Task SaveAnswerAsync(StudentAnswer studentAnswer)
        {
            try
            {
                if (studentAnswer == null)
                {
                    throw new ArgumentNullException(nameof(studentAnswer));
                }

                // Validate that the student exam exists and is not submitted
                var studentExam = await _studentExamRepository.GetByIdAsync(studentAnswer.StudentExamId);
                if (studentExam == null)
                {
                    throw new InvalidOperationException($"StudentExam with ID {studentAnswer.StudentExamId} not found");
                }

                if (studentExam.SubmittedAt.HasValue)
                {
                    throw new InvalidOperationException("Cannot save answer for submitted exam");
                }

                // Validate that the answer belongs to a question in this exam
                await ValidateAnswerBelongsToExam(studentAnswer);

                // Check if answer already exists for this question
                var existingAnswers = await _studentAnswerRepository.FindAsync(
                    sa => sa.StudentExamId == studentAnswer.StudentExamId && 
                          sa.QuestionId == studentAnswer.QuestionId);

                if (existingAnswers.Any())
                {
                    // Update existing answer
                    var existingAnswer = existingAnswers.First();
                    existingAnswer.AnswerId = studentAnswer.AnswerId;
                    existingAnswer.IsCorrect = await ValidateAnswerCorrectness(studentAnswer.AnswerId);
                    
                    await _studentAnswerRepository.UpdateAsync(existingAnswer);
                }
                else
                {
                    // Create new answer
                    studentAnswer.IsCorrect = await ValidateAnswerCorrectness(studentAnswer.AnswerId);
                    await _studentAnswerRepository.AddAsync(studentAnswer);
                }

                await _studentAnswerRepository.SaveChangesAsync();

                _logger.LogDebug("Answer saved for student exam {StudentExamId}, question {QuestionId}", 
                    studentAnswer.StudentExamId, studentAnswer.QuestionId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving answer for student exam {StudentExamId}", studentAnswer.StudentExamId);
                throw;
            }
        }

        public async Task<IEnumerable<StudentAnswer>> GetAnswersByStudentExamAsync(int studentExamId)
        {
            try
            {
                return await _studentAnswerRepository.FindAsync(sa => sa.StudentExamId == studentExamId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving answers for student exam {StudentExamId}", studentExamId);
                throw;
            }
        }

        private async Task ValidateAnswerBelongsToExam(StudentAnswer studentAnswer)
        {
            // Get the exam questions to validate the answer belongs to the exam
            var studentExam = await _studentExamRepository.GetWithAnswersAsync(studentAnswer.StudentExamId);
            if (studentExam == null)
            {
                throw new InvalidOperationException("StudentExam not found");
            }

            // For now, we'll assume the validation passes
            // In a more complete implementation, you'd check if the question belongs to the exam's questions
        }

        private async Task<bool> ValidateAnswerCorrectness(int? answerId)
        {
            if (answerId == null)
                return false;

            try
            {
                var answer = await _answerRepository.GetByIdAsync(answerId.Value);
                return answer?.IsCorrect ?? false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating answer correctness for answer ID {AnswerId}", answerId);
                return false;
            }
        }
    }
}
