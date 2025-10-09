using System;
using System.Collections.Generic;

namespace Core.DTOs
{
    // Base DTO for common report properties
    public class BaseReportDTO
    {
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
        public string ReportType { get; set; } = string.Empty;
        public string GeneratedBy { get; set; } = string.Empty;
    }

    // 1. Single student in single exam report
    public class StudentExamReportDTO : BaseReportDTO
    {
        public int StudentExamID { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public int ExamId { get; set; }
        public string ExamTitle { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public string TrackName { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public DateTime? ExamScheduledAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public int DurationMinutes { get; set; }
        public int Score { get; set; }
        public int FullMark { get; set; }
        public int PassMark { get; set; }
        public decimal Percentage { get; set; }
        public bool IsPassed { get; set; }
        public string ExamStatus { get; set; } = string.Empty;
        public List<QuestionAnswerDTO> QuestionAnswers { get; set; } = new List<QuestionAnswerDTO>();
    }

    // 2. Single student in all exams report
    public class StudentAllExamsReportDTO : BaseReportDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public string TrackName { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public List<StudentExamSummaryDTO> ExamSummaries { get; set; } = new List<StudentExamSummaryDTO>();
        public StudentPerformanceSummaryDTO PerformanceSummary { get; set; } = new StudentPerformanceSummaryDTO();
    }

    // 3. Single student in all exams by specific instructor
    public class StudentInstructorExamsReportDTO : BaseReportDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int InstructorId { get; set; }
        public string InstructorName { get; set; } = string.Empty;
        public List<StudentExamSummaryDTO> ExamSummaries { get; set; } = new List<StudentExamSummaryDTO>();
        public StudentPerformanceSummaryDTO PerformanceSummary { get; set; } = new StudentPerformanceSummaryDTO();
    }

    // 4. Single student in all exams in specific course
    public class StudentCourseExamsReportDTO : BaseReportDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string InstructorName { get; set; } = string.Empty;
        public List<StudentExamSummaryDTO> ExamSummaries { get; set; } = new List<StudentExamSummaryDTO>();
        public StudentPerformanceSummaryDTO PerformanceSummary { get; set; } = new StudentPerformanceSummaryDTO();
    }

    // 5. Single exam showing all students performance
    public class ExamStudentsReportDTO : BaseReportDTO
    {
        public int ExamId { get; set; }
        public string ExamTitle { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public string InstructorName { get; set; } = string.Empty;
        public DateTime? ScheduledAt { get; set; }
        public int DurationMinutes { get; set; }
        public int FullMark { get; set; }
        public int PassMark { get; set; }
        public string ExamStatus { get; set; } = string.Empty;
        public List<StudentExamSummaryDTO> StudentResults { get; set; } = new List<StudentExamSummaryDTO>();
        public ExamStatisticsDTO ExamStatistics { get; set; } = new ExamStatisticsDTO();
    }

    // 6. Single course by specific instructor
    public class InstructorCourseReportDTO : BaseReportDTO
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string TrackName { get; set; } = string.Empty;
        public List<ExamSummaryDTO> Exams { get; set; } = new List<ExamSummaryDTO>();
        public List<StudentCoursePerformanceDTO> StudentPerformances { get; set; } = new List<StudentCoursePerformanceDTO>();
        public CourseStatisticsDTO CourseStatistics { get; set; } = new CourseStatisticsDTO();
    }

    // 7. Single track in a branch
    public class TrackBranchReportDTO : BaseReportDTO
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; } = string.Empty;
        public int BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string SupervisorName { get; set; } = string.Empty;
        public List<CourseSummaryDTO> Courses { get; set; } = new List<CourseSummaryDTO>();
        public List<StudentTrackPerformanceDTO> StudentPerformances { get; set; } = new List<StudentTrackPerformanceDTO>();
        public TrackStatisticsDTO TrackStatistics { get; set; } = new TrackStatisticsDTO();
    }

    // 8. Single track over all branches
    public class TrackAllBranchesReportDTO : BaseReportDTO
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; } = string.Empty;
        public List<BranchTrackSummaryDTO> BranchSummaries { get; set; } = new List<BranchTrackSummaryDTO>();
        public TrackOverallStatisticsDTO OverallStatistics { get; set; } = new TrackOverallStatisticsDTO();
    }

    // Supporting DTOs
    public class QuestionAnswerDTO
    {
        public int QuestionId { get; set; }
        public string QuestionBody { get; set; } = string.Empty;
        public string QuestionType { get; set; } = string.Empty;
        public int QuestionMarks { get; set; }
        public List<AnswerDTO> AvailableAnswers { get; set; } = new List<AnswerDTO>();
        public List<AnswerDTO> StudentAnswers { get; set; } = new List<AnswerDTO>();
        public bool IsCorrect { get; set; }
        public int EarnedMarks { get; set; }
    }

    public class AnswerDTO
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public bool IsSelected { get; set; }
    }

    public class StudentExamSummaryDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int ExamId { get; set; }
        public string ExamTitle { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public DateTime? ScheduledAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public int Score { get; set; }
        public int FullMark { get; set; }
        public decimal Percentage { get; set; }
        public bool IsPassed { get; set; }
        public string ExamStatus { get; set; } = string.Empty;
    }

    public class StudentPerformanceSummaryDTO
    {
        public int TotalExams { get; set; }
        public int PassedExams { get; set; }
        public int FailedExams { get; set; }
        public decimal AverageScore { get; set; }
        public decimal AveragePercentage { get; set; }
        public int HighestScore { get; set; }
        public int LowestScore { get; set; }
        public decimal PassRate { get; set; }
    }

    public class ExamStatisticsDTO
    {
        public int TotalStudents { get; set; }
        public int StudentsAttempted { get; set; }
        public int StudentsPassed { get; set; }
        public int StudentsFailed { get; set; }
        public decimal AverageScore { get; set; }
        public decimal AveragePercentage { get; set; }
        public int HighestScore { get; set; }
        public int LowestScore { get; set; }
        public decimal PassRate { get; set; }
        public decimal AttemptRate { get; set; }
    }

    public class ExamSummaryDTO
    {
        public int ExamId { get; set; }
        public string ExamTitle { get; set; } = string.Empty;
        public DateTime? ScheduledAt { get; set; }
        public int DurationMinutes { get; set; }
        public int FullMark { get; set; }
        public int PassMark { get; set; }
        public string ExamStatus { get; set; } = string.Empty;
        public int TotalStudents { get; set; }
        public int StudentsAttempted { get; set; }
        public decimal AverageScore { get; set; }
        public decimal PassRate { get; set; }
    }

    public class StudentCoursePerformanceDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int TotalExams { get; set; }
        public int PassedExams { get; set; }
        public decimal AverageScore { get; set; }
        public decimal AveragePercentage { get; set; }
        public decimal PassRate { get; set; }
    }

    public class CourseStatisticsDTO
    {
        public int TotalStudents { get; set; }
        public int TotalExams { get; set; }
        public int CompletedExams { get; set; }
        public decimal AverageScore { get; set; }
        public decimal AveragePercentage { get; set; }
        public decimal OverallPassRate { get; set; }
        public int HighestScore { get; set; }
        public int LowestScore { get; set; }
    }

    public class CourseSummaryDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string InstructorName { get; set; } = string.Empty;
        public int TotalExams { get; set; }
        public int TotalStudents { get; set; }
        public decimal AverageScore { get; set; }
        public decimal PassRate { get; set; }
    }

    public class StudentTrackPerformanceDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int TotalCourses { get; set; }
        public int CompletedCourses { get; set; }
        public int TotalExams { get; set; }
        public int PassedExams { get; set; }
        public decimal AverageScore { get; set; }
        public decimal AveragePercentage { get; set; }
        public decimal PassRate { get; set; }
        public decimal CompletionRate { get; set; }
    }

    public class TrackStatisticsDTO
    {
        public int TotalStudents { get; set; }
        public int TotalCourses { get; set; }
        public int TotalExams { get; set; }
        public decimal AverageScore { get; set; }
        public decimal AveragePercentage { get; set; }
        public decimal OverallPassRate { get; set; }
        public decimal CourseCompletionRate { get; set; }
    }

    public class BranchTrackSummaryDTO
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string ManagerName { get; set; } = string.Empty;
        public int TotalStudents { get; set; }
        public int TotalExams { get; set; }
        public decimal AverageScore { get; set; }
        public decimal PassRate { get; set; }
        public decimal StudentPerformance { get; set; }
    }

    public class TrackOverallStatisticsDTO
    {
        public int TotalBranches { get; set; }
        public int TotalStudents { get; set; }
        public int TotalExams { get; set; }
        public decimal AverageScore { get; set; }
        public decimal AveragePercentage { get; set; }
        public decimal OverallPassRate { get; set; }
        public string BestPerformingBranch { get; set; } = string.Empty;
        public string WorstPerformingBranch { get; set; } = string.Empty;
    }
}
