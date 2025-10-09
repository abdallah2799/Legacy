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
    public class StudentExamService : IStudentExamService
    {
        private readonly IStudentExamRepository _studentExamRepository;
        private readonly IExamRepository _examRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICacheService _cacheService;
        private readonly ILogger<StudentExamService> _logger;

        public StudentExamService(
            IStudentExamRepository studentExamRepository,
            IExamRepository examRepository,
            IUserRepository userRepository,
            ICacheService cacheService,
            ILogger<StudentExamService> logger)
        {
            _studentExamRepository = studentExamRepository;
            _examRepository = examRepository;
            _userRepository = userRepository;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<StudentExam> StartExamAsync(int studentId, int examId)
        {
            try
            {
                // Validate student exists
                var student = await _userRepository.GetByIdAsync(studentId);
                if (student == null)
                {
                    throw new InvalidOperationException($"Student with ID {studentId} not found");
                }

                // Validate exam exists and is available
                var exam = await _examRepository.GetByIdAsync(examId);
                if (exam == null)
                {
                    throw new InvalidOperationException($"Exam with ID {examId} not found");
                }

                if (exam.Status != ExamStatusEnum.Started)
                {
                    throw new InvalidOperationException($"Exam is not currently active. Status: {exam.Status}");
                }

                // Check if student has already taken this exam (for final exams)
                if (exam.ExamTypeEnum == ExamTypeEnum.Final)
                {
                    var existingStudentExams = await _studentExamRepository.FindAsync(
                        se => se.StudentId == studentId && se.ExamId == examId);
                    
                    if (existingStudentExams.Any())
                    {
                        throw new InvalidOperationException("Student has already taken this final exam");
                    }
                }

                // Create new student exam record
                var studentExam = new StudentExam
                {
                    StudentId = studentId,
                    ExamId = examId,
                    StartedAt = DateTime.UtcNow,
                    SubmittedAt = null,
                    Score = null
                };

                await _studentExamRepository.AddAsync(studentExam);
                await _studentExamRepository.SaveChangesAsync();

                // Clear student exams cache
                await _cacheService.RemoveAsync(Constants.CacheKeys.StudentExams(studentId));

                _logger.LogInformation("Student {StudentId} started exam {ExamId}", studentId, examId);
                return studentExam;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error starting exam {ExamId} for student {StudentId}", examId, studentId);
                throw;
            }
        }

        public async Task SubmitExamAsync(int studentExamId)
        {
            try
            {
                var studentExam = await _studentExamRepository.GetByIdAsync(studentExamId);
                if (studentExam == null)
                {
                    throw new InvalidOperationException($"StudentExam with ID {studentExamId} not found");
                }

                if (studentExam.SubmittedAt.HasValue)
                {
                    throw new InvalidOperationException("Exam has already been submitted");
                }

                // Mark as submitted and calculate score
                studentExam.SubmittedAt = DateTime.UtcNow;
                await _studentExamRepository.UpdateAsync(studentExam);
                await _studentExamRepository.SaveChangesAsync();

                // Calculate score using stored procedure
                var score = await _studentExamRepository.CallCalculateScoreAsync(studentExamId);
                studentExam.Score = score;

                await _studentExamRepository.UpdateAsync(studentExam);
                await _studentExamRepository.SaveChangesAsync();

                // Clear caches
                await _cacheService.RemoveAsync(Constants.CacheKeys.StudentExams(studentExam.StudentId));

                _logger.LogInformation("Student exam {StudentExamId} submitted with score {Score}", studentExamId, score);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error submitting student exam {StudentExamId}", studentExamId);
                throw;
            }
        }

        public async Task<int> CalculateScoreAsync(int studentExamId)
        {
            try
            {
                var score = await _studentExamRepository.CallCalculateScoreAsync(studentExamId);
                _logger.LogInformation("Score calculated for student exam {StudentExamId}: {Score}", studentExamId, score);
                return score;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating score for student exam {StudentExamId}", studentExamId);
                throw;
            }
        }

        public async Task<IEnumerable<StudentExam>> GetByStudentAsync(int studentId)
        {
            try
            {
                var cacheKey = Constants.CacheKeys.StudentExams(studentId);
                return await _cacheService.GetOrCreateAsync(
                    cacheKey,
                    async () => (await _studentExamRepository.GetByStudentAsync(studentId)).ToList(),
                    Constants.Defaults.CACHE_USERS_EXPIRATION);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving student exams for student {StudentId}", studentId);
                throw;
            }
        }
    }
}
