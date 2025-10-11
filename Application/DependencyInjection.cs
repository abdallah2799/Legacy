using Application.Services;
using Application.Validators;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using FluentValidation;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext registration
            services.AddDbContext<LegacyDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies(); // enable lazy loading
            });

            // Memory Cache
            services.AddMemoryCache();

            // Repository registrations
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IStudentExamRepository, StudentExamRepository>();
            services.AddScoped<IStudentAnswerRepository, StudentAnswerRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddScoped<IBranchTrackRepository, BranchTrackRepository>();
            services.AddScoped<ITrackCourseRepository, TrackCourseRepository>();
            services.AddScoped<ICoursePolicyRepository, CoursePolicyRepository>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            services.AddScoped<ITranslationRepository, TranslationRepository>();
            services.AddScoped<ILogRepository, LogRepository>();

            // Service registrations
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ExamNotificationService>();

            // Authentication & User Management
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILogService, LogService>();

            // Student Services
            services.AddScoped<IStudentExamService, StudentExamService>();
            services.AddScoped<IStudentAnswerService, StudentAnswerService>();

            // Instructor Services
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IAnswerService, AnswerService>();

            // Admin Services
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ITrackService, TrackService>();
            services.AddScoped<IBranchTrackService, BranchTrackService>();
            services.AddScoped<ITrackCourseService, TrackCourseService>();
            services.AddScoped<ICoursePolicyService, CoursePolicyService>();
            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<ITranslationService, TranslationService>();

            // Existing services
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IReportService, ReportService>();

            // FluentValidation validators
            services.AddScoped<IValidator<Core.Models.User>, UserValidator>();
            services.AddScoped<IValidator<Exam>, ExamValidator>();
            services.AddScoped<IValidator<Core.Models.Question>, QuestionValidator>();
            services.AddScoped<IValidator<Core.Models.Applicant>, ApplicantValidator>();

            return services;
        }
    }
}