using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data
{
    public class LegacyDbContext : DbContext
    {
        public LegacyDbContext(DbContextOptions<LegacyDbContext> options)
            : base(options)
        {
        }

        // Core Entities
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }

        // Branch & Track Management
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<BranchTrack> BranchTracks { get; set; } // new
        public DbSet<TrackCourse> TrackCourses { get; set; }

        // Course Management
        public DbSet<Course> Courses { get; set; }
        public DbSet<CoursePolicy> CoursePolicies { get; set; }
        public DbSet<InstructorCourse> InstructorCourses { get; set; } // new

        // Exam System
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; } // new
        public DbSet<ExamQuestion> ExamQuestions { get; set; } // new
        public DbSet<StudentExam> StudentExams { get; set; } // new
        public DbSet<StudentAnswer> StudentAnswers { get; set; } // new

        // Other Tables
        public DbSet<Applicant> Applicants { get; set; } // new
        public DbSet<Translation> Translations { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all IEntityTypeConfiguration classes in the current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
