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
            // 1. DbContext registration remains Transient
            services.AddDbContext<LegacyDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            }, ServiceLifetime.Transient);

            // Memory Cache
            services.AddMemoryCache();

            // --- THIS IS THE FINAL FIX ---
            // 2. Change ALL Repository registrations to Transient
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IExamRepository, ExamRepository>();
            services.AddTransient<IStudentExamRepository, StudentExamRepository>();
            services.AddTransient<IStudentAnswerRepository, StudentAnswerRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IBranchRepository, BranchRepository>();
            services.AddTransient<ITrackRepository, TrackRepository>();
            services.AddTransient<IBranchTrackRepository, BranchTrackRepository>();
            services.AddTransient<ITrackCourseRepository, TrackCourseRepository>();
            services.AddTransient<ICoursePolicyRepository, CoursePolicyRepository>();
            services.AddTransient<IApplicantRepository, ApplicantRepository>();
            services.AddTransient<ITranslationRepository, TranslationRepository>();
            services.AddTransient<ILogRepository, LogRepository>();

            // 3. Service registrations remain Transient
            services.AddTransient<ICacheService, CacheService>();
            services.AddTransient<IValidationService, ValidationService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ExamNotificationService>();

            // Authentication & User Management
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILogService, LogService>();

            // Student Services
            services.AddTransient<IStudentExamService, StudentExamService>();
            services.AddTransient<IStudentAnswerService, StudentAnswerService>();

            // Instructor Services
            services.AddTransient<IExamService, ExamService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();

            // Admin Services
            services.AddTransient<IBranchService, BranchService>();
            services.AddTransient<ITrackService, TrackService>();
            services.AddTransient<IBranchTrackService, BranchTrackService>();
            services.AddTransient<ITrackCourseService, TrackCourseService>();
            services.AddTransient<ICoursePolicyService, CoursePolicyService>();
            services.AddTransient<IApplicantService, ApplicantService>();
            services.AddTransient<ITranslationService, TranslationService>();

            // Existing services
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IReportService, ReportService>();
            // ----------------------------------------------------

            // Validators are stateless and can remain Scoped
            services.AddScoped<IValidator<Core.Models.User>, UserValidator>();
            services.AddScoped<IValidator<Exam>, ExamValidator>();
            services.AddScoped<IValidator<Core.Models.Question>, QuestionValidator>();
            services.AddScoped<IValidator<Core.Models.Applicant>, ApplicantValidator>();

            return services;
        }
    }
}