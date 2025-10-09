using Core.Interfaces.Services;
using Core.Interfaces.Repositories;
using Core.Models;
using Common.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ApplicantService> _logger;

        public ApplicantService(
            IApplicantRepository applicantRepository,
            IUserRepository userRepository,
            ILogger<ApplicantService> logger)
        {
            _applicantRepository = applicantRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Applicant>> GetPendingApplicationsAsync()
        {
            try
            {
                return await _applicantRepository.FindAsync(a => a.Status == ApplicationStatus.Pending);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving pending applications");
                throw;
            }
        }

        public async Task ApproveApplicantAsync(int applicantId)
        {
            try
            {
                var applicant = await _applicantRepository.GetByIdAsync(applicantId);
                if (applicant == null)
                {
                    throw new InvalidOperationException($"Applicant with ID {applicantId} not found");
                }

                if (applicant.Status != ApplicationStatus.Pending)
                {
                    throw new InvalidOperationException($"Cannot approve applicant in status: {applicant.Status}");
                }

                // Create student user from applicant
                var student = new Student
                {
                    FullName = applicant.FullName,
                    Username = applicant.Username ?? GenerateUsername(applicant.FullName),
                    Email = applicant.Email,
                    Gender = applicant.Gender,
                    Age = applicant.Age,
                    Address = applicant.Address,
                    Phone = applicant.Phone,
                    PasswordHash = applicant.PasswordHash,
                    RoleEnum = Common.Enums.UserRoleEnum.Student,
                    BranchId = applicant.AcceptedBranchId ?? 0,
                    TrackId = applicant.AcceptedTrackId ?? 0,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await _userRepository.AddAsync(student);
                await _userRepository.SaveChangesAsync();

                // Update applicant status
                applicant.Status = ApplicationStatus.Approved;
                applicant.UpdatedAt = DateTime.UtcNow;
                await _applicantRepository.UpdateAsync(applicant);
                await _applicantRepository.SaveChangesAsync();

                _logger.LogInformation("Applicant {ApplicantId} approved and converted to student {StudentId}", 
                    applicantId, student.UserId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error approving applicant {ApplicantId}", applicantId);
                throw;
            }
        }

        public async Task RejectApplicantAsync(int applicantId)
        {
            try
            {
                var applicant = await _applicantRepository.GetByIdAsync(applicantId);
                if (applicant == null)
                {
                    throw new InvalidOperationException($"Applicant with ID {applicantId} not found");
                }

                if (applicant.Status != ApplicationStatus.Pending)
                {
                    throw new InvalidOperationException($"Cannot reject applicant in status: {applicant.Status}");
                }

                applicant.Status = ApplicationStatus.Rejected;
                applicant.UpdatedAt = DateTime.UtcNow;

                await _applicantRepository.UpdateAsync(applicant);
                await _applicantRepository.SaveChangesAsync();

                _logger.LogInformation("Applicant {ApplicantId} rejected", applicantId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error rejecting applicant {ApplicantId}", applicantId);
                throw;
            }
        }

        public async Task SubmitApplicationAsync(Applicant applicant)
        {
            try
            {
                if (applicant == null)
                {
                    throw new ArgumentNullException(nameof(applicant));
                }

                // Validate required fields
                if (string.IsNullOrWhiteSpace(applicant.FullName) ||
                    string.IsNullOrWhiteSpace(applicant.Email) ||
                    string.IsNullOrWhiteSpace(applicant.Phone))
                {
                    throw new InvalidOperationException("Required fields are missing");
                }

                // Set initial status and timestamps
                applicant.Status = ApplicationStatus.Pending;
                applicant.CreatedAt = DateTime.UtcNow;
                applicant.UpdatedAt = DateTime.UtcNow;

                await _applicantRepository.AddAsync(applicant);
                await _applicantRepository.SaveChangesAsync();

                _logger.LogInformation("Application submitted successfully: {ApplicantId}", applicant.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error submitting application");
                throw;
            }
        }

        private string GenerateUsername(string fullName)
        {
            // Simple username generation from full name
            var parts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var baseUsername = parts.Length > 1 
                ? $"{parts[0].ToLower()}.{parts[1].ToLower()}" 
                : parts[0].ToLower();
            
            return $"{baseUsername}{DateTime.UtcNow.Ticks % 10000}";
        }
    }
}
