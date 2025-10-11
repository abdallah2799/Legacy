using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Constants
    {
        // Cache Keys
        public static class CacheKeys
        {
            public const string COURSES = "courses";
            public const string TRACKS = "tracks";
            public const string BRANCHES = "branches";
            public const string USERS = "users";
            public const string ACTIVE_EXAMS = "active_exams";
            public const string COURSE_POLICIES = "course_policies";
            public const string TRANSLATIONS = "translations";
            
            // Dynamic cache keys
            public static string CourseQuestions(int courseId) => $"course_questions_{courseId}";
            public static string StudentExams(int studentId) => $"student_exams_{studentId}";
            public static string UserProfile(int userId) => $"user_profile_{userId}";
            public static string TrackCourses(int trackId) => $"track_courses_{trackId}";
        }

        // Default Values
        public static class Defaults
        {
            public const int MIN_EXAM_DURATION_MINUTES = 30;
            public const int MAX_EXAM_DURATION_MINUTES = 180;
            public const int DEFAULT_PASS_PERCENTAGE = 60;
            public const int MAX_EXAM_ATTEMPTS = 3;
            public const int MIN_QUESTION_MARKS = 1;
            public const int MAX_QUESTION_MARKS = 10;
            
            // Cache Expiration Times
            public static readonly TimeSpan CACHE_COURSES_EXPIRATION = TimeSpan.FromHours(2);
            public static readonly TimeSpan CACHE_TRACKS_EXPIRATION = TimeSpan.FromHours(2);
            public static readonly TimeSpan CACHE_BRANCHES_EXPIRATION = TimeSpan.FromHours(2);
            public static readonly TimeSpan CACHE_USERS_EXPIRATION = TimeSpan.FromMinutes(30);
            public static readonly TimeSpan CACHE_ACTIVE_EXAMS_EXPIRATION = TimeSpan.FromMinutes(5);
        }

        // Validation Rules
        public static class Validation
        {
            public const int MIN_PASSWORD_LENGTH = 8;
            public const int MAX_PASSWORD_LENGTH = 100;
            public const int MIN_AGE = 18;
            public const int MAX_AGE = 65;
            public const int MAX_FULLNAME_LENGTH = 100;
            public const int MAX_EMAIL_LENGTH = 255;
            public const int MAX_PHONE_LENGTH = 20;
            public const int MAX_ADDRESS_LENGTH = 500;
            public const int MAX_QUESTION_BODY_LENGTH = 1000;
        }
    }
}
