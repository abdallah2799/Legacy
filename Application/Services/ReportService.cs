using Core.DTOs;
using Core.Interfaces.Services;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Common.Helpers;

namespace Application.Services
{
    public class ReportService : IReportService
    {
        private readonly LegacyDbContext _context;
        private readonly ILogger<ReportService> _logger;

        public ReportService(LegacyDbContext context, ILogger<ReportService> logger)
        {
            _context = context;
            _logger = logger;
        }

        #region Stored Procedure Methods

        public async Task<StudentExamReportDTO> GetStudentExamReportAsync(int studentExamId)
        {
            try
            {
                var result = new StudentExamReportDTO();
                
                using var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "sp_GetStudentExamReport";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@StudentExamID", studentExamId));

                await _context.Database.OpenConnectionAsync();
                using var reader = await command.ExecuteReaderAsync();

                // Read exam details
                if (await reader.ReadAsync())
                {
                    result.StudentExamID = Convert.ToInt32(reader["StudentExamID"]);
                    result.StudentId = Convert.ToInt32(reader["StudentID"]);
                    result.StudentName = reader["StudentName"].ToString() ?? "";
                    result.StudentEmail = reader["StudentEmail"].ToString() ?? "";
                    result.ExamId = Convert.ToInt32(reader["ExamID"]);
                    result.ExamTitle = reader["ExamTitle"].ToString() ?? "";
                    result.CourseName = reader["CourseName"].ToString() ?? "";
                    result.TrackName = reader["TrackName"].ToString() ?? "";
                    result.BranchName = reader["BranchName"].ToString() ?? "";
                    result.ExamScheduledAt = reader["ScheduledAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["ScheduledAt"]);
                    result.StartedAt = reader["StartedAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["StartedAt"]);
                    result.SubmittedAt = reader["SubmittedAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["SubmittedAt"]);
                    result.DurationMinutes = Convert.ToInt32(reader["DurationMinutes"]);
                    result.Score = Convert.ToInt32(reader["Score"]);
                    result.FullMark = Convert.ToInt32(reader["FullMark"]);
                    result.PassMark = Convert.ToInt32(reader["PassMark"]);
                    result.Percentage = Convert.ToDecimal(reader["Percentage"]);
                    result.IsPassed = Convert.ToBoolean(reader["IsPassed"]);
                    result.ExamStatus = reader["ExamStatus"].ToString() ?? "";
                }

                await reader.NextResultAsync();

                // Read question answers
                var questionAnswers = new Dictionary<int, QuestionAnswerDTO>();
                while (await reader.ReadAsync())
                {
                    var questionId = Convert.ToInt32(reader["QuestionID"]);
                    if (!questionAnswers.ContainsKey(questionId))
                    {
                        questionAnswers[questionId] = new QuestionAnswerDTO
                        {
                            QuestionId = questionId,
                            QuestionBody = reader["QuestionBody"].ToString() ?? "",
                            QuestionType = reader["QuestionType"].ToString() ?? "",
                            QuestionMarks = Convert.ToInt32(reader["QuestionMarks"])
                        };
                    }

                    var answer = new AnswerDTO
                    {
                        AnswerId = Convert.ToInt32(reader["AnswerID"]),
                        AnswerText = reader["AnswerText"].ToString() ?? "",
                        IsCorrect = Convert.ToBoolean(reader["IsCorrect"]),
                        IsSelected = Convert.ToBoolean(reader["IsSelected"])
                    };

                    questionAnswers[questionId].AvailableAnswers.Add(answer);
                    if (answer.IsSelected)
                    {
                        questionAnswers[questionId].StudentAnswers.Add(answer);
                    }
                }

                result.QuestionAnswers = questionAnswers.Values.ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving student exam report for StudentExamID: {StudentExamID}", studentExamId);
                throw;
            }
        }

        public async Task<StudentAllExamsReportDTO> GetStudentAllExamsReportAsync(int studentId)
        {
            try
            {
                var result = new StudentAllExamsReportDTO();
                
                using var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "sp_GetStudentAllExamsReport";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@StudentID", studentId));

                await _context.Database.OpenConnectionAsync();
                using var reader = await command.ExecuteReaderAsync();

                // Read student details
                if (await reader.ReadAsync())
                {
                    result.StudentId = Convert.ToInt32(reader["StudentID"]);
                    result.StudentName = reader["StudentName"].ToString() ?? "";
                    result.StudentEmail = reader["StudentEmail"].ToString() ?? "";
                    result.TrackName = reader["TrackName"].ToString() ?? "";
                    result.BranchName = reader["BranchName"].ToString() ?? "";
                }

                await reader.NextResultAsync();

                // Read exam summaries
                while (await reader.ReadAsync())
                {
                    result.ExamSummaries.Add(new StudentExamSummaryDTO
                    {
                        StudentId = result.StudentId,
                        StudentName = result.StudentName,
                        ExamId = Convert.ToInt32(reader["ExamID"]),
                        ExamTitle = reader["ExamTitle"].ToString() ?? "",
                        CourseName = reader["CourseName"].ToString() ?? "",
                        ScheduledAt = reader["ScheduledAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["ScheduledAt"]),
                        StartedAt = reader["StartedAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["StartedAt"]),
                        SubmittedAt = reader["SubmittedAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["SubmittedAt"]),
                        Score = Convert.ToInt32(reader["Score"]),
                        FullMark = Convert.ToInt32(reader["FullMark"]),
                        Percentage = Convert.ToDecimal(reader["Percentage"]),
                        IsPassed = Convert.ToBoolean(reader["IsPassed"]),
                        ExamStatus = reader["ExamStatus"].ToString() ?? ""
                    });
                }

                await reader.NextResultAsync();

                // Read performance summary
                if (await reader.ReadAsync())
                {
                    result.PerformanceSummary = new StudentPerformanceSummaryDTO
                    {
                        TotalExams = Convert.ToInt32(reader["TotalExams"]),
                        PassedExams = Convert.ToInt32(reader["PassedExams"]),
                        FailedExams = Convert.ToInt32(reader["FailedExams"]),
                        AverageScore = Convert.ToDecimal(reader["AverageScore"]),
                        AveragePercentage = Convert.ToDecimal(reader["AveragePercentage"]),
                        HighestScore = Convert.ToInt32(reader["HighestScore"]),
                        LowestScore = Convert.ToInt32(reader["LowestScore"]),
                        PassRate = Convert.ToDecimal(reader["PassRate"])
                    };
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving student all exams report for StudentID: {StudentID}", studentId);
                throw;
            }
        }

        public async Task<StudentInstructorExamsReportDTO> GetStudentInstructorExamsReportAsync(int studentId, int instructorId)
        {
            try
            {
                var result = new StudentInstructorExamsReportDTO();
                
                using var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "sp_GetStudentInstructorExamsReport";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@StudentID", studentId));
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@InstructorID", instructorId));

                await _context.Database.OpenConnectionAsync();
                using var reader = await command.ExecuteReaderAsync();

                // Read student and instructor details
                if (await reader.ReadAsync())
                {
                    result.StudentId = Convert.ToInt32(reader["StudentID"]);
                    result.StudentName = reader["StudentName"].ToString() ?? "";
                    result.InstructorId = Convert.ToInt32(reader["InstructorID"]);
                    result.InstructorName = reader["InstructorName"].ToString() ?? "";
                }

                await reader.NextResultAsync();

                // Read exam summaries
                while (await reader.ReadAsync())
                {
                    result.ExamSummaries.Add(new StudentExamSummaryDTO
                    {
                        StudentId = result.StudentId,
                        StudentName = result.StudentName,
                        ExamId = Convert.ToInt32(reader["ExamID"]),
                        ExamTitle = reader["ExamTitle"].ToString() ?? "",
                        CourseName = reader["CourseName"].ToString() ?? "",
                        ScheduledAt = reader["ScheduledAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["ScheduledAt"]),
                        StartedAt = reader["StartedAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["StartedAt"]),
                        SubmittedAt = reader["SubmittedAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["SubmittedAt"]),
                        Score = Convert.ToInt32(reader["Score"]),
                        FullMark = Convert.ToInt32(reader["FullMark"]),
                        Percentage = Convert.ToDecimal(reader["Percentage"]),
                        IsPassed = Convert.ToBoolean(reader["IsPassed"]),
                        ExamStatus = reader["ExamStatus"].ToString() ?? ""
                    });
                }

                await reader.NextResultAsync();

                // Read performance summary
                if (await reader.ReadAsync())
                {
                    result.PerformanceSummary = new StudentPerformanceSummaryDTO
                    {
                        TotalExams = Convert.ToInt32(reader["TotalExams"]),
                        PassedExams = Convert.ToInt32(reader["PassedExams"]),
                        FailedExams = Convert.ToInt32(reader["FailedExams"]),
                        AverageScore = Convert.ToDecimal(reader["AverageScore"]),
                        AveragePercentage = Convert.ToDecimal(reader["AveragePercentage"]),
                        HighestScore = Convert.ToInt32(reader["HighestScore"]),
                        LowestScore = Convert.ToInt32(reader["LowestScore"]),
                        PassRate = Convert.ToDecimal(reader["PassRate"])
                    };
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving student instructor exams report for StudentID: {StudentID}, InstructorID: {InstructorID}", studentId, instructorId);
                throw;
            }
        }

        public async Task<StudentCourseExamsReportDTO> GetStudentCourseExamsReportAsync(int studentId, int courseId)
        {
            try
            {
                var result = new StudentCourseExamsReportDTO();
                
                using var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "sp_GetStudentCourseExamsReport";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@StudentID", studentId));
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@CourseID", courseId));

                await _context.Database.OpenConnectionAsync();
                using var reader = await command.ExecuteReaderAsync();

                // Read student and course details
                if (await reader.ReadAsync())
                {
                    result.StudentId = Convert.ToInt32(reader["StudentID"]);
                    result.StudentName = reader["StudentName"].ToString() ?? "";
                    result.CourseId = Convert.ToInt32(reader["CourseID"]);
                    result.CourseName = reader["CourseName"].ToString() ?? "";
                    result.InstructorName = reader["InstructorName"] == DBNull.Value ? "" : reader["InstructorName"].ToString() ?? "";
                }

                await reader.NextResultAsync();

                // Read exam summaries
                while (await reader.ReadAsync())
                {
                    result.ExamSummaries.Add(new StudentExamSummaryDTO
                    {
                        StudentId = result.StudentId,
                        StudentName = result.StudentName,
                        ExamId = Convert.ToInt32(reader["ExamID"]),
                        ExamTitle = reader["ExamTitle"].ToString() ?? "",
                        CourseName = reader["CourseName"].ToString() ?? "",
                        ScheduledAt = reader["ScheduledAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["ScheduledAt"]),
                        StartedAt = reader["StartedAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["StartedAt"]),
                        SubmittedAt = reader["SubmittedAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["SubmittedAt"]),
                        Score = Convert.ToInt32(reader["Score"]),
                        FullMark = Convert.ToInt32(reader["FullMark"]),
                        Percentage = Convert.ToDecimal(reader["Percentage"]),
                        IsPassed = Convert.ToBoolean(reader["IsPassed"]),
                        ExamStatus = reader["ExamStatus"].ToString() ?? ""
                    });
                }

                await reader.NextResultAsync();

                // Read performance summary
                if (await reader.ReadAsync())
                {
                    result.PerformanceSummary = new StudentPerformanceSummaryDTO
                    {
                        TotalExams = Convert.ToInt32(reader["TotalExams"]),
                        PassedExams = Convert.ToInt32(reader["PassedExams"]),
                        FailedExams = Convert.ToInt32(reader["FailedExams"]),
                        AverageScore = Convert.ToDecimal(reader["AverageScore"]),
                        AveragePercentage = Convert.ToDecimal(reader["AveragePercentage"]),
                        HighestScore = Convert.ToInt32(reader["HighestScore"]),
                        LowestScore = Convert.ToInt32(reader["LowestScore"]),
                        PassRate = Convert.ToDecimal(reader["PassRate"])
                    };
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving student course exams report for StudentID: {StudentID}, CourseID: {CourseID}", studentId, courseId);
                throw;
            }
        }

        public async Task<ExamStudentsReportDTO> GetExamStudentsReportAsync(int examId)
        {
            try
            {
                var result = new ExamStudentsReportDTO();
                
                using var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "sp_GetExamStudentsReport";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@ExamID", examId));

                await _context.Database.OpenConnectionAsync();
                using var reader = await command.ExecuteReaderAsync();

                // Read exam details
                if (await reader.ReadAsync())
                {
                    result.ExamId = Convert.ToInt32(reader["ExamID"]);
                    result.ExamTitle = reader["ExamTitle"].ToString() ?? "";
                    result.CourseName = reader["CourseName"].ToString() ?? "";
                    result.InstructorName = reader["InstructorName"] == DBNull.Value ? "" : reader["InstructorName"].ToString() ?? "";
                    result.ScheduledAt = reader["ScheduledAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["ScheduledAt"]);
                    result.DurationMinutes = Convert.ToInt32(reader["DurationMinutes"]);
                    result.FullMark = Convert.ToInt32(reader["FullMark"]);
                    result.PassMark = Convert.ToInt32(reader["PassMark"]);
                    result.ExamStatus = reader["ExamStatus"].ToString() ?? "";
                }

                await reader.NextResultAsync();

                // Read student results
                while (await reader.ReadAsync())
                {
                    result.StudentResults.Add(new StudentExamSummaryDTO
                    {
                        StudentId = Convert.ToInt32(reader["StudentID"]),
                        StudentName = reader["StudentName"].ToString() ?? "",
                        ExamId = result.ExamId,
                        ExamTitle = result.ExamTitle,
                        CourseName = result.CourseName,
                        ScheduledAt = result.ScheduledAt,
                        StartedAt = reader["StartedAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["StartedAt"]),
                        SubmittedAt = reader["SubmittedAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["SubmittedAt"]),
                        Score = Convert.ToInt32(reader["Score"]),
                        FullMark = Convert.ToInt32(reader["FullMark"]),
                        Percentage = Convert.ToDecimal(reader["Percentage"]),
                        IsPassed = Convert.ToBoolean(reader["IsPassed"]),
                        ExamStatus = reader["ExamStatus"].ToString() ?? ""
                    });
                }

                await reader.NextResultAsync();

                // Read exam statistics
                if (await reader.ReadAsync())
                {
                    result.ExamStatistics = new ExamStatisticsDTO
                    {
                        TotalStudents = Convert.ToInt32(reader["TotalStudents"]),
                        StudentsAttempted = Convert.ToInt32(reader["StudentsAttempted"]),
                        StudentsPassed = Convert.ToInt32(reader["StudentsPassed"]),
                        StudentsFailed = Convert.ToInt32(reader["StudentsFailed"]),
                        AverageScore = Convert.ToDecimal(reader["AverageScore"]),
                        AveragePercentage = Convert.ToDecimal(reader["AveragePercentage"]),
                        HighestScore = Convert.ToInt32(reader["HighestScore"]),
                        LowestScore = Convert.ToInt32(reader["LowestScore"]),
                        PassRate = Convert.ToDecimal(reader["PassRate"]),
                        AttemptRate = Convert.ToDecimal(reader["AttemptRate"])
                    };
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving exam students report for ExamID: {ExamID}", examId);
                throw;
            }
        }

        public async Task<InstructorCourseReportDTO> GetInstructorCourseReportAsync(int instructorId, int courseId)
        {
            try
            {
                var result = new InstructorCourseReportDTO();
                
                using var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "sp_GetInstructorCourseReport";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@InstructorID", instructorId));
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@CourseID", courseId));

                await _context.Database.OpenConnectionAsync();
                using var reader = await command.ExecuteReaderAsync();

                // Read instructor and course details
                if (await reader.ReadAsync())
                {
                    result.InstructorId = Convert.ToInt32(reader["InstructorID"]);
                    result.InstructorName = reader["InstructorName"].ToString() ?? "";
                    result.CourseId = Convert.ToInt32(reader["CourseID"]);
                    result.CourseName = reader["CourseName"].ToString() ?? "";
                    result.TrackName = reader["TrackName"].ToString() ?? "";
                }

                await reader.NextResultAsync();

                // Read exams
                while (await reader.ReadAsync())
                {
                    result.Exams.Add(new ExamSummaryDTO
                    {
                        ExamId = Convert.ToInt32(reader["ExamID"]),
                        ExamTitle = reader["ExamTitle"].ToString() ?? "",
                        ScheduledAt = reader["ScheduledAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["ScheduledAt"]),
                        DurationMinutes = Convert.ToInt32(reader["DurationMinutes"]),
                        FullMark = Convert.ToInt32(reader["FullMark"]),
                        PassMark = Convert.ToInt32(reader["PassMark"]),
                        ExamStatus = reader["ExamStatus"].ToString() ?? "",
                        TotalStudents = Convert.ToInt32(reader["TotalStudents"]),
                        StudentsAttempted = Convert.ToInt32(reader["StudentsAttempted"]),
                        AverageScore = Convert.ToDecimal(reader["AverageScore"]),
                        PassRate = Convert.ToDecimal(reader["PassRate"])
                    });
                }

                await reader.NextResultAsync();

                // Read student performances
                while (await reader.ReadAsync())
                {
                    result.StudentPerformances.Add(new StudentCoursePerformanceDTO
                    {
                        StudentId = Convert.ToInt32(reader["StudentID"]),
                        StudentName = reader["StudentName"].ToString() ?? "",
                        TotalExams = Convert.ToInt32(reader["TotalExams"]),
                        PassedExams = Convert.ToInt32(reader["PassedExams"]),
                        AverageScore = Convert.ToDecimal(reader["AverageScore"]),
                        AveragePercentage = Convert.ToDecimal(reader["AveragePercentage"]),
                        PassRate = Convert.ToDecimal(reader["PassRate"])
                    });
                }

                await reader.NextResultAsync();

                // Read course statistics
                if (await reader.ReadAsync())
                {
                    result.CourseStatistics = new CourseStatisticsDTO
                    {
                        TotalStudents = Convert.ToInt32(reader["TotalStudents"]),
                        TotalExams = Convert.ToInt32(reader["TotalExams"]),
                        CompletedExams = Convert.ToInt32(reader["CompletedExams"]),
                        AverageScore = Convert.ToDecimal(reader["AverageScore"]),
                        AveragePercentage = Convert.ToDecimal(reader["AveragePercentage"]),
                        OverallPassRate = Convert.ToDecimal(reader["OverallPassRate"]),
                        HighestScore = Convert.ToInt32(reader["HighestScore"]),
                        LowestScore = Convert.ToInt32(reader["LowestScore"])
                    };
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving instructor course report for InstructorID: {InstructorID}, CourseID: {CourseID}", instructorId, courseId);
                throw;
            }
        }

        public async Task<TrackBranchReportDTO> GetTrackBranchReportAsync(int trackId, int branchId)
        {
            try
            {
                var result = new TrackBranchReportDTO();
                
                using var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "sp_GetTrackBranchReport";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@TrackID", trackId));
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@BranchID", branchId));

                await _context.Database.OpenConnectionAsync();
                using var reader = await command.ExecuteReaderAsync();

                // Read track and branch details
                if (await reader.ReadAsync())
                {
                    result.TrackId = Convert.ToInt32(reader["TrackID"]);
                    result.TrackName = reader["TrackName"].ToString() ?? "";
                    result.BranchId = Convert.ToInt32(reader["BranchID"]);
                    result.BranchName = reader["BranchName"].ToString() ?? "";
                    result.SupervisorName = reader["SupervisorName"] == DBNull.Value ? "" : reader["SupervisorName"].ToString() ?? "";
                }

                await reader.NextResultAsync();

                // Read courses
                while (await reader.ReadAsync())
                {
                    result.Courses.Add(new CourseSummaryDTO
                    {
                        CourseId = Convert.ToInt32(reader["CourseID"]),
                        CourseName = reader["CourseName"].ToString() ?? "",
                        InstructorName = reader["InstructorName"] == DBNull.Value ? "" : reader["InstructorName"].ToString() ?? "",
                        TotalExams = Convert.ToInt32(reader["TotalExams"]),
                        TotalStudents = Convert.ToInt32(reader["TotalStudents"]),
                        AverageScore = Convert.ToDecimal(reader["AverageScore"]),
                        PassRate = Convert.ToDecimal(reader["PassRate"])
                    });
                }

                await reader.NextResultAsync();

                // Read student performances
                while (await reader.ReadAsync())
                {
                    result.StudentPerformances.Add(new StudentTrackPerformanceDTO
                    {
                        StudentId = Convert.ToInt32(reader["StudentID"]),
                        StudentName = reader["StudentName"].ToString() ?? "",
                        TotalCourses = Convert.ToInt32(reader["TotalCourses"]),
                        CompletedCourses = Convert.ToInt32(reader["CompletedCourses"]),
                        TotalExams = Convert.ToInt32(reader["TotalExams"]),
                        PassedExams = Convert.ToInt32(reader["PassedExams"]),
                        AverageScore = Convert.ToDecimal(reader["AverageScore"]),
                        AveragePercentage = Convert.ToDecimal(reader["AveragePercentage"]),
                        PassRate = Convert.ToDecimal(reader["PassRate"]),
                        CompletionRate = Convert.ToDecimal(reader["CompletionRate"])
                    });
                }

                await reader.NextResultAsync();

                // Read track statistics
                if (await reader.ReadAsync())
                {
                    result.TrackStatistics = new TrackStatisticsDTO
                    {
                        TotalStudents = Convert.ToInt32(reader["TotalStudents"]),
                        TotalCourses = Convert.ToInt32(reader["TotalCourses"]),
                        TotalExams = Convert.ToInt32(reader["TotalExams"]),
                        AverageScore = Convert.ToDecimal(reader["AverageScore"]),
                        AveragePercentage = Convert.ToDecimal(reader["AveragePercentage"]),
                        OverallPassRate = Convert.ToDecimal(reader["OverallPassRate"]),
                        CourseCompletionRate = Convert.ToDecimal(reader["CourseCompletionRate"])
                    };
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving track branch report for TrackID: {TrackID}, BranchID: {BranchID}", trackId, branchId);
                throw;
            }
        }

        public async Task<TrackAllBranchesReportDTO> GetTrackAllBranchesReportAsync(int trackId)
        {
            try
            {
                var result = new TrackAllBranchesReportDTO();
                
                using var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "sp_GetTrackAllBranchesReport";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@TrackID", trackId));

                await _context.Database.OpenConnectionAsync();
                using var reader = await command.ExecuteReaderAsync();

                // Read track details
                if (await reader.ReadAsync())
                {
                    result.TrackId = Convert.ToInt32(reader["TrackID"]);
                    result.TrackName = reader["TrackName"].ToString() ?? "";
                }

                await reader.NextResultAsync();

                // Read branch summaries
                while (await reader.ReadAsync())
                {
                    result.BranchSummaries.Add(new BranchTrackSummaryDTO
                    {
                        BranchId = Convert.ToInt32(reader["BranchID"]),
                        BranchName = reader["BranchName"].ToString() ?? "",
                        ManagerName = reader["ManagerName"] == DBNull.Value ? "" : reader["ManagerName"].ToString() ?? "",
                        TotalStudents = Convert.ToInt32(reader["TotalStudents"]),
                        TotalExams = Convert.ToInt32(reader["TotalExams"]),
                        AverageScore = Convert.ToDecimal(reader["AverageScore"]),
                        PassRate = Convert.ToDecimal(reader["PassRate"]),
                        StudentPerformance = Convert.ToDecimal(reader["StudentPerformance"])
                    });
                }

                await reader.NextResultAsync();

                // Read overall statistics
                if (await reader.ReadAsync())
                {
                    result.OverallStatistics = new TrackOverallStatisticsDTO
                    {
                        TotalBranches = Convert.ToInt32(reader["TotalBranches"]),
                        TotalStudents = Convert.ToInt32(reader["TotalStudents"]),
                        TotalExams = Convert.ToInt32(reader["TotalExams"]),
                        AverageScore = Convert.ToDecimal(reader["AverageScore"]),
                        AveragePercentage = Convert.ToDecimal(reader["AveragePercentage"]),
                        OverallPassRate = Convert.ToDecimal(reader["OverallPassRate"]),
                        BestPerformingBranch = reader["BestPerformingBranch"] == DBNull.Value ? "" : reader["BestPerformingBranch"].ToString() ?? "",
                        WorstPerformingBranch = reader["WorstPerformingBranch"] == DBNull.Value ? "" : reader["WorstPerformingBranch"].ToString() ?? ""
                    };
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving track all branches report for TrackID: {TrackID}", trackId);
                throw;
            }
        }

        #endregion

        #region PDF Generation Methods

        public async Task<byte[]> GenerateStudentExamReportPDFAsync(int studentExamId)
        {
            try
            {
                var reportData = await GetStudentExamReportAsync(studentExamId);
                return GenerateStudentExamReportPDF(reportData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating student exam report PDF for StudentExamID: {StudentExamID}", studentExamId);
                throw;
            }
        }

        public async Task<byte[]> GenerateStudentAllExamsReportPDFAsync(int studentId)
        {
            try
            {
                var reportData = await GetStudentAllExamsReportAsync(studentId);
                return GenerateStudentAllExamsReportPDF(reportData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating student all exams report PDF for StudentID: {StudentID}", studentId);
                throw;
            }
        }

        public async Task<byte[]> GenerateExamStudentsReportPDFAsync(int examId)
        {
            try
            {
                var reportData = await GetExamStudentsReportAsync(examId);
                return GenerateExamStudentsReportPDF(reportData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating exam students report PDF for ExamID: {ExamID}", examId);
                throw;
            }
        }

        public async Task<byte[]> GenerateInstructorCourseReportPDFAsync(int instructorId, int courseId)
        {
            try
            {
                var reportData = await GetInstructorCourseReportAsync(instructorId, courseId);
                return GenerateInstructorCourseReportPDF(reportData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating instructor course report PDF for InstructorID: {InstructorID}, CourseID: {CourseID}", instructorId, courseId);
                throw;
            }
        }

        public async Task<byte[]> GenerateTrackBranchReportPDFAsync(int trackId, int branchId)
        {
            try
            {
                var reportData = await GetTrackBranchReportAsync(trackId, branchId);
                return GenerateTrackBranchReportPDF(reportData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating track branch report PDF for TrackID: {TrackID}, BranchID: {BranchID}", trackId, branchId);
                throw;
            }
        }

        public async Task<byte[]> GenerateTrackAllBranchesReportPDFAsync(int trackId)
        {
            try
            {
                var reportData = await GetTrackAllBranchesReportAsync(trackId);
                return GenerateTrackAllBranchesReportPDF(reportData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating track all branches report PDF for TrackID: {TrackID}", trackId);
                throw;
            }
        }

        #endregion

        #region Excel Generation Methods

        public async Task<byte[]> GenerateStudentExamReportExcelAsync(int studentExamId)
        {
            try
            {
                var reportData = await GetStudentExamReportAsync(studentExamId);
                return GenerateStudentExamReportExcel(reportData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating student exam report Excel for StudentExamID: {StudentExamID}", studentExamId);
                throw;
            }
        }

        public async Task<byte[]> GenerateStudentAllExamsReportExcelAsync(int studentId)
        {
            try
            {
                var reportData = await GetStudentAllExamsReportAsync(studentId);
                return GenerateStudentAllExamsReportExcel(reportData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating student all exams report Excel for StudentID: {StudentID}", studentId);
                throw;
            }
        }

        public async Task<byte[]> GenerateExamStudentsReportExcelAsync(int examId)
        {
            try
            {
                var reportData = await GetExamStudentsReportAsync(examId);
                return GenerateExamStudentsReportExcel(reportData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating exam students report Excel for ExamID: {ExamID}", examId);
                throw;
            }
        }

        public async Task<byte[]> GenerateInstructorCourseReportExcelAsync(int instructorId, int courseId)
        {
            try
            {
                var reportData = await GetInstructorCourseReportAsync(instructorId, courseId);
                return GenerateInstructorCourseReportExcel(reportData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating instructor course report Excel for InstructorID: {InstructorID}, CourseID: {CourseID}", instructorId, courseId);
                throw;
            }
        }

        public async Task<byte[]> GenerateTrackBranchReportExcelAsync(int trackId, int branchId)
        {
            try
            {
                var reportData = await GetTrackBranchReportAsync(trackId, branchId);
                return GenerateTrackBranchReportExcel(reportData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating track branch report Excel for TrackID: {TrackID}, BranchID: {BranchID}", trackId, branchId);
                throw;
            }
        }

        public async Task<byte[]> GenerateTrackAllBranchesReportExcelAsync(int trackId)
        {
            try
            {
                var reportData = await GetTrackAllBranchesReportAsync(trackId);
                return GenerateTrackAllBranchesReportExcel(reportData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating track all branches report Excel for TrackID: {TrackID}", trackId);
                throw;
            }
        }

        #endregion

        #region Legacy Methods (for backward compatibility)

        public async Task<byte[]> GenerateExamReportAsync(int examId)
        {
            try
            {
                return await GenerateExamStudentsReportPDFAsync(examId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating exam report for ExamID: {ExamID}", examId);
                throw;
            }
        }

        public async Task<byte[]> GenerateStudentReportAsync(int studentId)
        {
            try
            {
                return await GenerateStudentAllExamsReportPDFAsync(studentId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating student report for StudentID: {StudentID}", studentId);
                throw;
            }
        }

        public async Task<byte[]> GenerateTrackReportAsync(int trackId)
        {
            try
            {
                return await GenerateTrackAllBranchesReportPDFAsync(trackId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating track report for TrackID: {TrackID}", trackId);
                throw;
            }
        }

        public async Task<byte[]> GenerateBranchReportAsync(int branchId)
        {
            try
            {
                // This would need a specific branch report stored procedure
                // For now, return empty byte array
                return new byte[0];
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating branch report for BranchID: {BranchID}", branchId);
                throw;
            }
        }

        public async Task<byte[]> GenerateExamReportExcelAsync(int examId)
        {
            try
            {
                return await GenerateExamStudentsReportExcelAsync(examId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating exam report Excel for ExamID: {ExamID}", examId);
                throw;
            }
        }

        public async Task<byte[]> GenerateStudentReportExcelAsync(int studentId)
        {
            try
            {
                return await GenerateStudentAllExamsReportExcelAsync(studentId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating student report Excel for StudentID: {StudentID}", studentId);
                throw;
            }
        }

        #endregion

        #region Private Helper Methods

        private byte[] GenerateStudentExamReportPDF(StudentExamReportDTO reportData)
        {
            using var memoryStream = new MemoryStream();
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            // Title
            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            var smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            document.Add(new Paragraph($"Student Exam Report", titleFont));
            document.Add(new Paragraph($"Generated on: {reportData.GeneratedAt:yyyy-MM-dd HH:mm}", smallFont));
            document.Add(new Paragraph(" "));

            // Student Information
            document.Add(new Paragraph($"Student: {reportData.StudentName}", normalFont));
            document.Add(new Paragraph($"Email: {reportData.StudentEmail}", normalFont));
            document.Add(new Paragraph($"Track: {reportData.TrackName}", normalFont));
            document.Add(new Paragraph($"Branch: {reportData.BranchName}", normalFont));
            document.Add(new Paragraph(" "));

            // Exam Information
            document.Add(new Paragraph($"Exam: {reportData.ExamTitle}", normalFont));
            document.Add(new Paragraph($"Course: {reportData.CourseName}", normalFont));
            document.Add(new Paragraph($"Score: {reportData.Score}/{reportData.FullMark} ({reportData.Percentage:F1}%)", normalFont));
            document.Add(new Paragraph($"Status: {(reportData.IsPassed ? "Passed" : "Failed")}", normalFont));
            document.Add(new Paragraph(" "));

            // Question Details
            document.Add(new Paragraph("Question Details:", normalFont));
            foreach (var question in reportData.QuestionAnswers)
            {
                document.Add(new Paragraph($"Q{question.QuestionId}: {question.QuestionBody}", normalFont));
                document.Add(new Paragraph($"Type: {question.QuestionType}, Marks: {question.QuestionMarks}", smallFont));
                
                foreach (var answer in question.AvailableAnswers)
                {
                    var answerText = answer.AnswerText;
                    if (answer.IsCorrect) answerText += " (Correct)";
                    if (answer.IsSelected) answerText += " [Selected]";
                    document.Add(new Paragraph($"  - {answerText}", smallFont));
                }
                document.Add(new Paragraph(" "));
            }

            document.Close();
            return memoryStream.ToArray();
        }

        private byte[] GenerateStudentAllExamsReportPDF(StudentAllExamsReportDTO reportData)
        {
            using var memoryStream = new MemoryStream();
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            var smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            document.Add(new Paragraph($"Student All Exams Report", titleFont));
            document.Add(new Paragraph($"Generated on: {reportData.GeneratedAt:yyyy-MM-dd HH:mm}", smallFont));
            document.Add(new Paragraph(" "));

            // Student Information
            document.Add(new Paragraph($"Student: {reportData.StudentName}", normalFont));
            document.Add(new Paragraph($"Email: {reportData.StudentEmail}", normalFont));
            document.Add(new Paragraph($"Track: {reportData.TrackName}", normalFont));
            document.Add(new Paragraph($"Branch: {reportData.BranchName}", normalFont));
            document.Add(new Paragraph(" "));

            // Performance Summary
            document.Add(new Paragraph("Performance Summary:", normalFont));
            document.Add(new Paragraph($"Total Exams: {reportData.PerformanceSummary.TotalExams}", normalFont));
            document.Add(new Paragraph($"Passed: {reportData.PerformanceSummary.PassedExams}", normalFont));
            document.Add(new Paragraph($"Failed: {reportData.PerformanceSummary.FailedExams}", normalFont));
            document.Add(new Paragraph($"Average Score: {reportData.PerformanceSummary.AverageScore:F1}", normalFont));
            document.Add(new Paragraph($"Average Percentage: {reportData.PerformanceSummary.AveragePercentage:F1}%", normalFont));
            document.Add(new Paragraph($"Pass Rate: {reportData.PerformanceSummary.PassRate:F1}%", normalFont));
            document.Add(new Paragraph(" "));

            // Exam Details
            document.Add(new Paragraph("Exam Details:", normalFont));
            foreach (var exam in reportData.ExamSummaries)
            {
                document.Add(new Paragraph($"• {exam.ExamTitle} ({exam.CourseName})", normalFont));
                document.Add(new Paragraph($"  Score: {exam.Score}/{exam.FullMark} ({exam.Percentage:F1}%) - {(exam.IsPassed ? "Passed" : "Failed")}", smallFont));
                document.Add(new Paragraph($"  Scheduled: {exam.ScheduledAt:yyyy-MM-dd HH:mm}", smallFont));
                document.Add(new Paragraph(" "));
            }

            document.Close();
            return memoryStream.ToArray();
        }

        private byte[] GenerateExamStudentsReportPDF(ExamStudentsReportDTO reportData)
        {
            using var memoryStream = new MemoryStream();
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            var smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            document.Add(new Paragraph($"Exam Students Report", titleFont));
            document.Add(new Paragraph($"Generated on: {reportData.GeneratedAt:yyyy-MM-dd HH:mm}", smallFont));
            document.Add(new Paragraph(" "));

            // Exam Information
            document.Add(new Paragraph($"Exam: {reportData.ExamTitle}", normalFont));
            document.Add(new Paragraph($"Course: {reportData.CourseName}", normalFont));
            document.Add(new Paragraph($"Instructor: {reportData.InstructorName}", normalFont));
            document.Add(new Paragraph($"Scheduled: {reportData.ScheduledAt:yyyy-MM-dd HH:mm}", normalFont));
            document.Add(new Paragraph($"Duration: {reportData.DurationMinutes} minutes", normalFont));
            document.Add(new Paragraph($"Full Mark: {reportData.FullMark}, Pass Mark: {reportData.PassMark}", normalFont));
            document.Add(new Paragraph(" "));

            // Statistics
            document.Add(new Paragraph("Statistics:", normalFont));
            document.Add(new Paragraph($"Total Students: {reportData.ExamStatistics.TotalStudents}", normalFont));
            document.Add(new Paragraph($"Students Attempted: {reportData.ExamStatistics.StudentsAttempted}", normalFont));
            document.Add(new Paragraph($"Students Passed: {reportData.ExamStatistics.StudentsPassed}", normalFont));
            document.Add(new Paragraph($"Students Failed: {reportData.ExamStatistics.StudentsFailed}", normalFont));
            document.Add(new Paragraph($"Average Score: {reportData.ExamStatistics.AverageScore:F1}", normalFont));
            document.Add(new Paragraph($"Average Percentage: {reportData.ExamStatistics.AveragePercentage:F1}%", normalFont));
            document.Add(new Paragraph($"Pass Rate: {reportData.ExamStatistics.PassRate:F1}%", normalFont));
            document.Add(new Paragraph(" "));

            // Student Results
            document.Add(new Paragraph("Student Results:", normalFont));
            foreach (var student in reportData.StudentResults)
            {
                document.Add(new Paragraph($"• {student.StudentName}", normalFont));
                document.Add(new Paragraph($"  Score: {student.Score}/{student.FullMark} ({student.Percentage:F1}%) - {(student.IsPassed ? "Passed" : "Failed")}", smallFont));
                document.Add(new Paragraph(" "));
            }

            document.Close();
            return memoryStream.ToArray();
        }

        private byte[] GenerateInstructorCourseReportPDF(InstructorCourseReportDTO reportData)
        {
            using var memoryStream = new MemoryStream();
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            var smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            document.Add(new Paragraph($"Instructor Course Report", titleFont));
            document.Add(new Paragraph($"Generated on: {reportData.GeneratedAt:yyyy-MM-dd HH:mm}", smallFont));
            document.Add(new Paragraph(" "));

            // Instructor and Course Information
            document.Add(new Paragraph($"Instructor: {reportData.InstructorName}", normalFont));
            document.Add(new Paragraph($"Course: {reportData.CourseName}", normalFont));
            document.Add(new Paragraph($"Track: {reportData.TrackName}", normalFont));
            document.Add(new Paragraph(" "));

            // Course Statistics
            document.Add(new Paragraph("Course Statistics:", normalFont));
            document.Add(new Paragraph($"Total Students: {reportData.CourseStatistics.TotalStudents}", normalFont));
            document.Add(new Paragraph($"Total Exams: {reportData.CourseStatistics.TotalExams}", normalFont));
            document.Add(new Paragraph($"Completed Exams: {reportData.CourseStatistics.CompletedExams}", normalFont));
            document.Add(new Paragraph($"Average Score: {reportData.CourseStatistics.AverageScore:F1}", normalFont));
            document.Add(new Paragraph($"Average Percentage: {reportData.CourseStatistics.AveragePercentage:F1}%", normalFont));
            document.Add(new Paragraph($"Overall Pass Rate: {reportData.CourseStatistics.OverallPassRate:F1}%", normalFont));
            document.Add(new Paragraph(" "));

            // Exams
            document.Add(new Paragraph("Exams:", normalFont));
            foreach (var exam in reportData.Exams)
            {
                document.Add(new Paragraph($"• {exam.ExamTitle}", normalFont));
                document.Add(new Paragraph($"  Scheduled: {exam.ScheduledAt:yyyy-MM-dd HH:mm}", smallFont));
                document.Add(new Paragraph($"  Students: {exam.StudentsAttempted}/{exam.TotalStudents}, Avg Score: {exam.AverageScore:F1}, Pass Rate: {exam.PassRate:F1}%", smallFont));
                document.Add(new Paragraph(" "));
            }

            document.Close();
            return memoryStream.ToArray();
        }

        private byte[] GenerateTrackBranchReportPDF(TrackBranchReportDTO reportData)
        {
            using var memoryStream = new MemoryStream();
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            var smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            document.Add(new Paragraph($"Track Branch Report", titleFont));
            document.Add(new Paragraph($"Generated on: {reportData.GeneratedAt:yyyy-MM-dd HH:mm}", smallFont));
            document.Add(new Paragraph(" "));

            // Track and Branch Information
            document.Add(new Paragraph($"Track: {reportData.TrackName}", normalFont));
            document.Add(new Paragraph($"Branch: {reportData.BranchName}", normalFont));
            document.Add(new Paragraph($"Supervisor: {reportData.SupervisorName}", normalFont));
            document.Add(new Paragraph(" "));

            // Track Statistics
            document.Add(new Paragraph("Track Statistics:", normalFont));
            document.Add(new Paragraph($"Total Students: {reportData.TrackStatistics.TotalStudents}", normalFont));
            document.Add(new Paragraph($"Total Courses: {reportData.TrackStatistics.TotalCourses}", normalFont));
            document.Add(new Paragraph($"Total Exams: {reportData.TrackStatistics.TotalExams}", normalFont));
            document.Add(new Paragraph($"Average Score: {reportData.TrackStatistics.AverageScore:F1}", normalFont));
            document.Add(new Paragraph($"Average Percentage: {reportData.TrackStatistics.AveragePercentage:F1}%", normalFont));
            document.Add(new Paragraph($"Overall Pass Rate: {reportData.TrackStatistics.OverallPassRate:F1}%", normalFont));
            document.Add(new Paragraph($"Course Completion Rate: {reportData.TrackStatistics.CourseCompletionRate:F1}%", normalFont));
            document.Add(new Paragraph(" "));

            // Courses
            document.Add(new Paragraph("Courses:", normalFont));
            foreach (var course in reportData.Courses)
            {
                document.Add(new Paragraph($"• {course.CourseName} (Instructor: {course.InstructorName})", normalFont));
                document.Add(new Paragraph($"  Students: {course.TotalStudents}, Exams: {course.TotalExams}, Avg Score: {course.AverageScore:F1}, Pass Rate: {course.PassRate:F1}%", smallFont));
                document.Add(new Paragraph(" "));
            }

            document.Close();
            return memoryStream.ToArray();
        }

        private byte[] GenerateTrackAllBranchesReportPDF(TrackAllBranchesReportDTO reportData)
        {
            using var memoryStream = new MemoryStream();
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            var smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            document.Add(new Paragraph($"Track All Branches Report", titleFont));
            document.Add(new Paragraph($"Generated on: {reportData.GeneratedAt:yyyy-MM-dd HH:mm}", smallFont));
            document.Add(new Paragraph(" "));

            // Track Information
            document.Add(new Paragraph($"Track: {reportData.TrackName}", normalFont));
            document.Add(new Paragraph(" "));

            // Overall Statistics
            document.Add(new Paragraph("Overall Statistics:", normalFont));
            document.Add(new Paragraph($"Total Branches: {reportData.OverallStatistics.TotalBranches}", normalFont));
            document.Add(new Paragraph($"Total Students: {reportData.OverallStatistics.TotalStudents}", normalFont));
            document.Add(new Paragraph($"Total Exams: {reportData.OverallStatistics.TotalExams}", normalFont));
            document.Add(new Paragraph($"Average Score: {reportData.OverallStatistics.AverageScore:F1}", normalFont));
            document.Add(new Paragraph($"Average Percentage: {reportData.OverallStatistics.AveragePercentage:F1}%", normalFont));
            document.Add(new Paragraph($"Overall Pass Rate: {reportData.OverallStatistics.OverallPassRate:F1}%", normalFont));
            document.Add(new Paragraph($"Best Performing Branch: {reportData.OverallStatistics.BestPerformingBranch}", normalFont));
            document.Add(new Paragraph($"Worst Performing Branch: {reportData.OverallStatistics.WorstPerformingBranch}", normalFont));
            document.Add(new Paragraph(" "));

            // Branch Summaries
            document.Add(new Paragraph("Branch Performance:", normalFont));
            foreach (var branch in reportData.BranchSummaries)
            {
                document.Add(new Paragraph($"• {branch.BranchName} (Manager: {branch.ManagerName})", normalFont));
                document.Add(new Paragraph($"  Students: {branch.TotalStudents}, Exams: {branch.TotalExams}, Avg Score: {branch.AverageScore:F1}, Pass Rate: {branch.PassRate:F1}%", smallFont));
                document.Add(new Paragraph(" "));
            }

            document.Close();
            return memoryStream.ToArray();
        }

        private byte[] GenerateStudentExamReportExcel(StudentExamReportDTO reportData)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Student Exam Report");

            // Headers
            worksheet.Cell(1, 1).Value = "Student Exam Report";
            worksheet.Cell(1, 1).Style.Font.Bold = true;
            worksheet.Cell(1, 1).Style.Font.FontSize = 16;

            worksheet.Cell(2, 1).Value = "Generated on:";
            worksheet.Cell(2, 2).Value = reportData.GeneratedAt.ToString("yyyy-MM-dd HH:mm");

            // Student Information
            worksheet.Cell(4, 1).Value = "Student Information";
            worksheet.Cell(4, 1).Style.Font.Bold = true;
            worksheet.Cell(5, 1).Value = "Student Name:";
            worksheet.Cell(5, 2).Value = reportData.StudentName;
            worksheet.Cell(6, 1).Value = "Email:";
            worksheet.Cell(6, 2).Value = reportData.StudentEmail;
            worksheet.Cell(7, 1).Value = "Track:";
            worksheet.Cell(7, 2).Value = reportData.TrackName;
            worksheet.Cell(8, 1).Value = "Branch:";
            worksheet.Cell(8, 2).Value = reportData.BranchName;

            // Exam Information
            worksheet.Cell(10, 1).Value = "Exam Information";
            worksheet.Cell(10, 1).Style.Font.Bold = true;
            worksheet.Cell(11, 1).Value = "Exam Title:";
            worksheet.Cell(11, 2).Value = reportData.ExamTitle;
            worksheet.Cell(12, 1).Value = "Course:";
            worksheet.Cell(12, 2).Value = reportData.CourseName;
            worksheet.Cell(13, 1).Value = "Score:";
            worksheet.Cell(13, 2).Value = $"{reportData.Score}/{reportData.FullMark} ({reportData.Percentage:F1}%)";
            worksheet.Cell(14, 1).Value = "Status:";
            worksheet.Cell(14, 2).Value = reportData.IsPassed ? "Passed" : "Failed";

            // Question Details
            int startRow = 16;
            worksheet.Cell(startRow, 1).Value = "Question Details";
            worksheet.Cell(startRow, 1).Style.Font.Bold = true;
            startRow++;

            foreach (var question in reportData.QuestionAnswers)
            {
                worksheet.Cell(startRow, 1).Value = $"Q{question.QuestionId}: {question.QuestionBody}";
                worksheet.Cell(startRow, 1).Style.Font.Bold = true;
                startRow++;
                
                worksheet.Cell(startRow, 1).Value = $"Type: {question.QuestionType}, Marks: {question.QuestionMarks}";
                startRow++;

                foreach (var answer in question.AvailableAnswers)
                {
                    var answerText = answer.AnswerText;
                    if (answer.IsCorrect) answerText += " (Correct)";
                    if (answer.IsSelected) answerText += " [Selected]";
                    worksheet.Cell(startRow, 2).Value = $"• {answerText}";
                    startRow++;
                }
                startRow++;
            }

            using var memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            return memoryStream.ToArray();
        }

        private byte[] GenerateStudentAllExamsReportExcel(StudentAllExamsReportDTO reportData)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Student All Exams Report");

            // Headers
            worksheet.Cell(1, 1).Value = "Student All Exams Report";
            worksheet.Cell(1, 1).Style.Font.Bold = true;
            worksheet.Cell(1, 1).Style.Font.FontSize = 16;

            worksheet.Cell(2, 1).Value = "Generated on:";
            worksheet.Cell(2, 2).Value = reportData.GeneratedAt.ToString("yyyy-MM-dd HH:mm");

            // Student Information
            worksheet.Cell(4, 1).Value = "Student Information";
            worksheet.Cell(4, 1).Style.Font.Bold = true;
            worksheet.Cell(5, 1).Value = "Student Name:";
            worksheet.Cell(5, 2).Value = reportData.StudentName;
            worksheet.Cell(6, 1).Value = "Email:";
            worksheet.Cell(6, 2).Value = reportData.StudentEmail;
            worksheet.Cell(7, 1).Value = "Track:";
            worksheet.Cell(7, 2).Value = reportData.TrackName;
            worksheet.Cell(8, 1).Value = "Branch:";
            worksheet.Cell(8, 2).Value = reportData.BranchName;

            // Performance Summary
            worksheet.Cell(10, 1).Value = "Performance Summary";
            worksheet.Cell(10, 1).Style.Font.Bold = true;
            worksheet.Cell(11, 1).Value = "Total Exams:";
            worksheet.Cell(11, 2).Value = reportData.PerformanceSummary.TotalExams;
            worksheet.Cell(12, 1).Value = "Passed:";
            worksheet.Cell(12, 2).Value = reportData.PerformanceSummary.PassedExams;
            worksheet.Cell(13, 1).Value = "Failed:";
            worksheet.Cell(13, 2).Value = reportData.PerformanceSummary.FailedExams;
            worksheet.Cell(14, 1).Value = "Average Score:";
            worksheet.Cell(14, 2).Value = reportData.PerformanceSummary.AverageScore;
            worksheet.Cell(15, 1).Value = "Average Percentage:";
            worksheet.Cell(15, 2).Value = $"{reportData.PerformanceSummary.AveragePercentage:F1}%";
            worksheet.Cell(16, 1).Value = "Pass Rate:";
            worksheet.Cell(16, 2).Value = $"{reportData.PerformanceSummary.PassRate:F1}%";

            // Exam Details Table
            int startRow = 18;
            worksheet.Cell(startRow, 1).Value = "Exam Details";
            worksheet.Cell(startRow, 1).Style.Font.Bold = true;
            startRow++;

            // Table headers
            worksheet.Cell(startRow, 1).Value = "Exam Title";
            worksheet.Cell(startRow, 2).Value = "Course";
            worksheet.Cell(startRow, 3).Value = "Scheduled At";
            worksheet.Cell(startRow, 4).Value = "Score";
            worksheet.Cell(startRow, 5).Value = "Percentage";
            worksheet.Cell(startRow, 6).Value = "Status";
            worksheet.Cell(startRow, 1).Style.Font.Bold = true;
            worksheet.Cell(startRow, 2).Style.Font.Bold = true;
            worksheet.Cell(startRow, 3).Style.Font.Bold = true;
            worksheet.Cell(startRow, 4).Style.Font.Bold = true;
            worksheet.Cell(startRow, 5).Style.Font.Bold = true;
            worksheet.Cell(startRow, 6).Style.Font.Bold = true;
            startRow++;

            foreach (var exam in reportData.ExamSummaries)
            {
                worksheet.Cell(startRow, 1).Value = exam.ExamTitle;
                worksheet.Cell(startRow, 2).Value = exam.CourseName;
                worksheet.Cell(startRow, 3).Value = exam.ScheduledAt?.ToString("yyyy-MM-dd HH:mm") ?? "Not scheduled";
                worksheet.Cell(startRow, 4).Value = $"{exam.Score}/{exam.FullMark}";
                worksheet.Cell(startRow, 5).Value = $"{exam.Percentage:F1}%";
                worksheet.Cell(startRow, 6).Value = exam.IsPassed ? "Passed" : "Failed";
                startRow++;
            }

            using var memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            return memoryStream.ToArray();
        }

        private byte[] GenerateExamStudentsReportExcel(ExamStudentsReportDTO reportData)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Exam Students Report");

            // Headers
            worksheet.Cell(1, 1).Value = "Exam Students Report";
            worksheet.Cell(1, 1).Style.Font.Bold = true;
            worksheet.Cell(1, 1).Style.Font.FontSize = 16;

            worksheet.Cell(2, 1).Value = "Generated on:";
            worksheet.Cell(2, 2).Value = reportData.GeneratedAt.ToString("yyyy-MM-dd HH:mm");

            // Exam Information
            worksheet.Cell(4, 1).Value = "Exam Information";
            worksheet.Cell(4, 1).Style.Font.Bold = true;
            worksheet.Cell(5, 1).Value = "Exam Title:";
            worksheet.Cell(5, 2).Value = reportData.ExamTitle;
            worksheet.Cell(6, 1).Value = "Course:";
            worksheet.Cell(6, 2).Value = reportData.CourseName;
            worksheet.Cell(7, 1).Value = "Instructor:";
            worksheet.Cell(7, 2).Value = reportData.InstructorName;
            worksheet.Cell(8, 1).Value = "Scheduled At:";
            worksheet.Cell(8, 2).Value = reportData.ScheduledAt?.ToString("yyyy-MM-dd HH:mm") ?? "Not scheduled";
            worksheet.Cell(9, 1).Value = "Duration:";
            worksheet.Cell(9, 2).Value = $"{reportData.DurationMinutes} minutes";
            worksheet.Cell(10, 1).Value = "Full Mark:";
            worksheet.Cell(10, 2).Value = reportData.FullMark;
            worksheet.Cell(11, 1).Value = "Pass Mark:";
            worksheet.Cell(11, 2).Value = reportData.PassMark;

            // Statistics
            worksheet.Cell(13, 1).Value = "Statistics";
            worksheet.Cell(13, 1).Style.Font.Bold = true;
            worksheet.Cell(14, 1).Value = "Total Students:";
            worksheet.Cell(14, 2).Value = reportData.ExamStatistics.TotalStudents;
            worksheet.Cell(15, 1).Value = "Students Attempted:";
            worksheet.Cell(15, 2).Value = reportData.ExamStatistics.StudentsAttempted;
            worksheet.Cell(16, 1).Value = "Students Passed:";
            worksheet.Cell(16, 2).Value = reportData.ExamStatistics.StudentsPassed;
            worksheet.Cell(17, 1).Value = "Students Failed:";
            worksheet.Cell(17, 2).Value = reportData.ExamStatistics.StudentsFailed;
            worksheet.Cell(18, 1).Value = "Average Score:";
            worksheet.Cell(18, 2).Value = reportData.ExamStatistics.AverageScore;
            worksheet.Cell(19, 1).Value = "Average Percentage:";
            worksheet.Cell(19, 2).Value = $"{reportData.ExamStatistics.AveragePercentage:F1}%";
            worksheet.Cell(20, 1).Value = "Pass Rate:";
            worksheet.Cell(20, 2).Value = $"{reportData.ExamStatistics.PassRate:F1}%";
            worksheet.Cell(21, 1).Value = "Attempt Rate:";
            worksheet.Cell(21, 2).Value = $"{reportData.ExamStatistics.AttemptRate:F1}%";

            // Student Results Table
            int startRow = 23;
            worksheet.Cell(startRow, 1).Value = "Student Results";
            worksheet.Cell(startRow, 1).Style.Font.Bold = true;
            startRow++;

            // Table headers
            worksheet.Cell(startRow, 1).Value = "Student Name";
            worksheet.Cell(startRow, 2).Value = "Score";
            worksheet.Cell(startRow, 3).Value = "Percentage";
            worksheet.Cell(startRow, 4).Value = "Status";
            worksheet.Cell(startRow, 1).Style.Font.Bold = true;
            worksheet.Cell(startRow, 2).Style.Font.Bold = true;
            worksheet.Cell(startRow, 3).Style.Font.Bold = true;
            worksheet.Cell(startRow, 4).Style.Font.Bold = true;
            startRow++;

            foreach (var student in reportData.StudentResults)
            {
                worksheet.Cell(startRow, 1).Value = student.StudentName;
                worksheet.Cell(startRow, 2).Value = $"{student.Score}/{student.FullMark}";
                worksheet.Cell(startRow, 3).Value = $"{student.Percentage:F1}%";
                worksheet.Cell(startRow, 4).Value = student.IsPassed ? "Passed" : "Failed";
                startRow++;
            }

            using var memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            return memoryStream.ToArray();
        }

        private byte[] GenerateInstructorCourseReportExcel(InstructorCourseReportDTO reportData)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Instructor Course Report");

            // Headers
            worksheet.Cell(1, 1).Value = "Instructor Course Report";
            worksheet.Cell(1, 1).Style.Font.Bold = true;
            worksheet.Cell(1, 1).Style.Font.FontSize = 16;

            worksheet.Cell(2, 1).Value = "Generated on:";
            worksheet.Cell(2, 2).Value = reportData.GeneratedAt.ToString("yyyy-MM-dd HH:mm");

            // Instructor and Course Information
            worksheet.Cell(4, 1).Value = "Instructor and Course Information";
            worksheet.Cell(4, 1).Style.Font.Bold = true;
            worksheet.Cell(5, 1).Value = "Instructor:";
            worksheet.Cell(5, 2).Value = reportData.InstructorName;
            worksheet.Cell(6, 1).Value = "Course:";
            worksheet.Cell(6, 2).Value = reportData.CourseName;
            worksheet.Cell(7, 1).Value = "Track:";
            worksheet.Cell(7, 2).Value = reportData.TrackName;

            // Course Statistics
            worksheet.Cell(9, 1).Value = "Course Statistics";
            worksheet.Cell(9, 1).Style.Font.Bold = true;
            worksheet.Cell(10, 1).Value = "Total Students:";
            worksheet.Cell(10, 2).Value = reportData.CourseStatistics.TotalStudents;
            worksheet.Cell(11, 1).Value = "Total Exams:";
            worksheet.Cell(11, 2).Value = reportData.CourseStatistics.TotalExams;
            worksheet.Cell(12, 1).Value = "Completed Exams:";
            worksheet.Cell(12, 2).Value = reportData.CourseStatistics.CompletedExams;
            worksheet.Cell(13, 1).Value = "Average Score:";
            worksheet.Cell(13, 2).Value = reportData.CourseStatistics.AverageScore;
            worksheet.Cell(14, 1).Value = "Average Percentage:";
            worksheet.Cell(14, 2).Value = $"{reportData.CourseStatistics.AveragePercentage:F1}%";
            worksheet.Cell(15, 1).Value = "Overall Pass Rate:";
            worksheet.Cell(15, 2).Value = $"{reportData.CourseStatistics.OverallPassRate:F1}%";

            using var memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            return memoryStream.ToArray();
        }

        private byte[] GenerateTrackBranchReportExcel(TrackBranchReportDTO reportData)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Track Branch Report");

            // Headers
            worksheet.Cell(1, 1).Value = "Track Branch Report";
            worksheet.Cell(1, 1).Style.Font.Bold = true;
            worksheet.Cell(1, 1).Style.Font.FontSize = 16;

            worksheet.Cell(2, 1).Value = "Generated on:";
            worksheet.Cell(2, 2).Value = reportData.GeneratedAt.ToString("yyyy-MM-dd HH:mm");

            // Track and Branch Information
            worksheet.Cell(4, 1).Value = "Track and Branch Information";
            worksheet.Cell(4, 1).Style.Font.Bold = true;
            worksheet.Cell(5, 1).Value = "Track:";
            worksheet.Cell(5, 2).Value = reportData.TrackName;
            worksheet.Cell(6, 1).Value = "Branch:";
            worksheet.Cell(6, 2).Value = reportData.BranchName;
            worksheet.Cell(7, 1).Value = "Supervisor:";
            worksheet.Cell(7, 2).Value = reportData.SupervisorName;

            // Track Statistics
            worksheet.Cell(9, 1).Value = "Track Statistics";
            worksheet.Cell(9, 1).Style.Font.Bold = true;
            worksheet.Cell(10, 1).Value = "Total Students:";
            worksheet.Cell(10, 2).Value = reportData.TrackStatistics.TotalStudents;
            worksheet.Cell(11, 1).Value = "Total Courses:";
            worksheet.Cell(11, 2).Value = reportData.TrackStatistics.TotalCourses;
            worksheet.Cell(12, 1).Value = "Total Exams:";
            worksheet.Cell(12, 2).Value = reportData.TrackStatistics.TotalExams;
            worksheet.Cell(13, 1).Value = "Average Score:";
            worksheet.Cell(13, 2).Value = reportData.TrackStatistics.AverageScore;
            worksheet.Cell(14, 1).Value = "Average Percentage:";
            worksheet.Cell(14, 2).Value = $"{reportData.TrackStatistics.AveragePercentage:F1}%";
            worksheet.Cell(15, 1).Value = "Overall Pass Rate:";
            worksheet.Cell(15, 2).Value = $"{reportData.TrackStatistics.OverallPassRate:F1}%";
            worksheet.Cell(16, 1).Value = "Course Completion Rate:";
            worksheet.Cell(16, 2).Value = $"{reportData.TrackStatistics.CourseCompletionRate:F1}%";

            using var memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            return memoryStream.ToArray();
        }

        private byte[] GenerateTrackAllBranchesReportExcel(TrackAllBranchesReportDTO reportData)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Track All Branches Report");

            // Headers
            worksheet.Cell(1, 1).Value = "Track All Branches Report";
            worksheet.Cell(1, 1).Style.Font.Bold = true;
            worksheet.Cell(1, 1).Style.Font.FontSize = 16;

            worksheet.Cell(2, 1).Value = "Generated on:";
            worksheet.Cell(2, 2).Value = reportData.GeneratedAt.ToString("yyyy-MM-dd HH:mm");

            // Track Information
            worksheet.Cell(4, 1).Value = "Track Information";
            worksheet.Cell(4, 1).Style.Font.Bold = true;
            worksheet.Cell(5, 1).Value = "Track:";
            worksheet.Cell(5, 2).Value = reportData.TrackName;

            // Overall Statistics
            worksheet.Cell(7, 1).Value = "Overall Statistics";
            worksheet.Cell(7, 1).Style.Font.Bold = true;
            worksheet.Cell(8, 1).Value = "Total Branches:";
            worksheet.Cell(8, 2).Value = reportData.OverallStatistics.TotalBranches;
            worksheet.Cell(9, 1).Value = "Total Students:";
            worksheet.Cell(9, 2).Value = reportData.OverallStatistics.TotalStudents;
            worksheet.Cell(10, 1).Value = "Total Exams:";
            worksheet.Cell(10, 2).Value = reportData.OverallStatistics.TotalExams;
            worksheet.Cell(11, 1).Value = "Average Score:";
            worksheet.Cell(11, 2).Value = reportData.OverallStatistics.AverageScore;
            worksheet.Cell(12, 1).Value = "Average Percentage:";
            worksheet.Cell(12, 2).Value = $"{reportData.OverallStatistics.AveragePercentage:F1}%";
            worksheet.Cell(13, 1).Value = "Overall Pass Rate:";
            worksheet.Cell(13, 2).Value = $"{reportData.OverallStatistics.OverallPassRate:F1}%";
            worksheet.Cell(14, 1).Value = "Best Performing Branch:";
            worksheet.Cell(14, 2).Value = reportData.OverallStatistics.BestPerformingBranch;
            worksheet.Cell(15, 1).Value = "Worst Performing Branch:";
            worksheet.Cell(15, 2).Value = reportData.OverallStatistics.WorstPerformingBranch;

            using var memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            return memoryStream.ToArray();
        }

        #endregion
    }
}