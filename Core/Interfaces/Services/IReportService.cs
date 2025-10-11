using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IReportService
    {
        // Existing methods
        Task<byte[]> GenerateExamReportAsync(int examId);
        Task<byte[]> GenerateStudentReportAsync(int studentId);
        Task<byte[]> GenerateTrackReportAsync(int trackId);
        Task<byte[]> GenerateBranchReportAsync(int branchId);
        Task<byte[]> GenerateExamReportExcelAsync(int examId);
        Task<byte[]> GenerateStudentReportExcelAsync(int studentId);

        // New comprehensive report methods using stored procedures
        Task<StudentExamReportDTO> GetStudentExamReportAsync(int studentExamId);
        Task<StudentAllExamsReportDTO> GetStudentAllExamsReportAsync(int studentId);
        Task<StudentInstructorExamsReportDTO> GetStudentInstructorExamsReportAsync(int studentId, int instructorId);
        Task<StudentCourseExamsReportDTO> GetStudentCourseExamsReportAsync(int studentId, int courseId);
        Task<ExamStudentsReportDTO> GetExamStudentsReportAsync(int examId);
        Task<InstructorCourseReportDTO> GetInstructorCourseReportAsync(int instructorId, int courseId);
        Task<TrackBranchReportDTO> GetTrackBranchReportAsync(int trackId, int branchId);
        Task<TrackAllBranchesReportDTO> GetTrackAllBranchesReportAsync(int trackId);

        // Generate reports as PDF/Excel using DTOs
        Task<byte[]> GenerateStudentExamReportPDFAsync(int studentExamId);
        Task<byte[]> GenerateStudentExamReportExcelAsync(int studentExamId);
        Task<byte[]> GenerateStudentAllExamsReportPDFAsync(int studentId);
        Task<byte[]> GenerateStudentAllExamsReportExcelAsync(int studentId);
        Task<byte[]> GenerateExamStudentsReportPDFAsync(int examId);
        Task<byte[]> GenerateExamStudentsReportExcelAsync(int examId);
        Task<byte[]> GenerateInstructorCourseReportPDFAsync(int instructorId, int courseId);
        Task<byte[]> GenerateInstructorCourseReportExcelAsync(int instructorId, int courseId);
        Task<byte[]> GenerateTrackBranchReportPDFAsync(int trackId, int branchId);
        Task<byte[]> GenerateTrackBranchReportExcelAsync(int trackId, int branchId);
        Task<byte[]> GenerateTrackAllBranchesReportPDFAsync(int trackId);
        Task<byte[]> GenerateTrackAllBranchesReportExcelAsync(int trackId);
    }
}
