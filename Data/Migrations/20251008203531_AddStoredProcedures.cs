using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // GetExamStudentsReport
            migrationBuilder.Sql(@"
                CREATE   PROCEDURE [dbo].[sp_GetExamStudentsReport]
                    @ExamID INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Get exam details
                    SELECT 
                        e.ExamID,
                        e.Title AS ExamTitle,
                        c.Name AS CourseName,
                        i.FullName AS InstructorName,
                        e.ScheduledAt,
                        e.DurationMinutes,
                        e.FullMark,
                        e.PassMark,
                        e.Status AS ExamStatus
                    FROM Exams e
                    INNER JOIN TrackCourses tc ON e.TrackCourseID = tc.TrackCourseID
                    INNER JOIN Courses c ON tc.CourseID = c.CourseID
                    LEFT JOIN InstructorCourses ic ON c.CourseID = ic.CourseID
                    LEFT JOIN Users i ON ic.InstructorID = i.UserID
                    WHERE e.ExamID = @ExamID;

                    -- Get student results
                    SELECT 
                        s.UserID AS StudentID,
                        s.FullName AS StudentName,
                        se.StartedAt,
                        se.SubmittedAt,
                        se.Score,
                        e.FullMark,
                        CASE 
                            WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                            ELSE 0 
                        END AS Percentage,
                        CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END AS IsPassed,
                        e.Status AS ExamStatus
                    FROM StudentExams se
                    INNER JOIN Users s ON se.StudentID = s.UserID
                    INNER JOIN Exams e ON se.ExamID = e.ExamID
                    WHERE se.ExamID = @ExamID
                    ORDER BY se.Score DESC, s.FullName;

                    -- Get exam statistics
                    SELECT 
                        COUNT(DISTINCT s.UserID) AS TotalStudents,
                        COUNT(se.StudentExamID) AS StudentsAttempted,
                        SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS StudentsPassed,
                        SUM(CASE WHEN se.Score < e.PassMark THEN 1 ELSE 0 END) AS StudentsFailed,
                        AVG(CAST(se.Score AS DECIMAL(5,2))) AS AverageScore,
                        AVG(CASE 
                            WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                            ELSE 0 
                        END) AS AveragePercentage,
                        MAX(se.Score) AS HighestScore,
                        MIN(se.Score) AS LowestScore,
                        CASE 
                            WHEN COUNT(se.StudentExamID) > 0 THEN 
                                CAST(SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS DECIMAL(5,2)) / COUNT(se.StudentExamID) * 100
                            ELSE 0 
                        END AS PassRate,
                        CASE 
                            WHEN COUNT(DISTINCT s.UserID) > 0 THEN 
                                CAST(COUNT(se.StudentExamID) AS DECIMAL(5,2)) / COUNT(DISTINCT s.UserID) * 100
                            ELSE 0 
                        END AS AttemptRate
                    FROM Users s
                    INNER JOIN TrackCourses tc ON s.TrackID = tc.TrackID
                    INNER JOIN Courses c ON tc.CourseID = c.CourseID
                    INNER JOIN Exams e ON e.TrackCourseID = tc.TrackCourseID
                    LEFT JOIN StudentExams se ON s.UserID = se.StudentID AND e.ExamID = se.ExamID
                    WHERE e.ExamID = @ExamID;
                END
            ");
            // CalculateStudentExamScore
            migrationBuilder.Sql(@"
                CREATE   PROCEDURE [dbo].[sp_CalculateStudentExamScore]
                    @StudentExamID INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    DECLARE @TotalScore INT = 0;

                    -- =========================
                    -- 1. TrueFalse / ChooseOne
                    -- =========================
                    SELECT @TotalScore = @TotalScore + ISNULL(SUM(Q.Marks), 0)
                    FROM StudentAnswers SA
                    INNER JOIN Questions Q ON SA.QuestionID = Q.QuestionID
                    INNER JOIN Answers A ON SA.AnswerID = A.AnswerID
                    WHERE SA.StudentExamID = @StudentExamID
                      AND Q.Type IN ('TrueFalse', 'ChooseOne')
                      AND A.IsCorrect = 1;

                    -- =========================
                    -- 2. ChooseAll
                    -- =========================
                    ;WITH QuestionSummary AS
                    (
                        SELECT 
                            Q.QuestionID,
                            Q.Marks,
                            TotalCorrectAnswers = COUNT(CASE WHEN A.IsCorrect = 1 THEN 1 END)
                        FROM Questions Q
                        INNER JOIN Answers A ON Q.QuestionID = A.QuestionID
                        WHERE Q.Type = 'ChooseAll'
                        GROUP BY Q.QuestionID, Q.Marks
                    ),
                    StudentChoices AS
                    (
                        SELECT 
                            SA.QuestionID,
                            SelectedCount = COUNT(*),
                            CorrectSelectedCount = COUNT(CASE WHEN A.IsCorrect = 1 THEN 1 END)
                        FROM StudentAnswers SA
                        INNER JOIN Answers A ON SA.AnswerID = A.AnswerID
                        INNER JOIN Questions Q ON SA.QuestionID = Q.QuestionID
                        WHERE SA.StudentExamID = @StudentExamID AND Q.Type = 'ChooseAll'
                        GROUP BY SA.QuestionID
                    )
                    SELECT @TotalScore = @TotalScore + ISNULL(SUM(QS.Marks), 0)
                    FROM QuestionSummary QS
                    INNER JOIN StudentChoices SC ON QS.QuestionID = SC.QuestionID
                    WHERE QS.TotalCorrectAnswers = SC.SelectedCount
                      AND QS.TotalCorrectAnswers = SC.CorrectSelectedCount;

                    -- =========================
                    -- Update StudentExam score
                    -- =========================
                    UPDATE StudentExams
                    SET Score = @TotalScore,
                        SubmittedAt = COALESCE(SubmittedAt, GETDATE())
                    WHERE StudentExamID = @StudentExamID;

                    SELECT @TotalScore AS FinalScore;
                END
            ");
            // GetTrackBranchReport
            migrationBuilder.Sql(@"
                CREATE   PROCEDURE [dbo].[sp_GetTrackBranchReport]
                    @TrackID INT,
                    @BranchID INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Get track and branch details
                    SELECT 
                        t.TrackID,
                        t.Name AS TrackName,
                        b.BranchID,
                        b.Name AS BranchName,
                        i.FullName AS SupervisorName
                    FROM Tracks t
                    INNER JOIN BranchTracks bt ON t.TrackID = bt.TrackID
                    INNER JOIN Branches b ON bt.BranchID = b.BranchID
                    LEFT JOIN Users i ON bt.SupervisorID = i.UserID
                    WHERE t.TrackID = @TrackID AND b.BranchID = @BranchID;

                    -- Get courses in this track
                    SELECT 
                        c.CourseID,
                        c.Name AS CourseName,
                        i.FullName AS InstructorName,
                        COUNT(DISTINCT e.ExamID) AS TotalExams,
                        COUNT(DISTINCT s.UserID) AS TotalStudents,
                        AVG(CAST(se.Score AS DECIMAL(5,2))) AS AverageScore,
                        CASE 
                            WHEN COUNT(se.StudentExamID) > 0 THEN 
                                CAST(SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS DECIMAL(5,2)) / COUNT(se.StudentExamID) * 100
                            ELSE 0 
                        END AS PassRate
                    FROM Courses c
                    INNER JOIN TrackCourses tc ON c.CourseID = tc.CourseID
                    INNER JOIN Tracks t ON tc.TrackID = t.TrackID
                    LEFT JOIN InstructorCourses ic ON c.CourseID = ic.CourseID
                    LEFT JOIN Users i ON ic.InstructorID = i.UserID
                    LEFT JOIN Exams e ON e.TrackCourseID = tc.TrackCourseID
                    LEFT JOIN Users s ON s.TrackID = t.TrackID
                    LEFT JOIN StudentExams se ON s.UserID = se.StudentID AND e.ExamID = se.ExamID
                    WHERE t.TrackID = @TrackID
                    GROUP BY c.CourseID, c.Name, i.FullName
                    ORDER BY c.Name;

                    -- Get student performances
                    SELECT 
                        s.UserID AS StudentID,
                        s.FullName AS StudentName,
                        COUNT(DISTINCT c.CourseID) AS TotalCourses,
                        COUNT(DISTINCT CASE WHEN se.StudentExamID IS NOT NULL THEN c.CourseID END) AS CompletedCourses,
                        COUNT(se.StudentExamID) AS TotalExams,
                        SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS PassedExams,
                        AVG(CAST(se.Score AS DECIMAL(5,2))) AS AverageScore,
                        AVG(CASE 
                            WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                            ELSE 0 
                        END) AS AveragePercentage,
                        CASE 
                            WHEN COUNT(se.StudentExamID) > 0 THEN 
                                CAST(SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS DECIMAL(5,2)) / COUNT(se.StudentExamID) * 100
                            ELSE 0 
                        END AS PassRate,
                        CASE 
                            WHEN COUNT(DISTINCT c.CourseID) > 0 THEN 
                                CAST(COUNT(DISTINCT CASE WHEN se.StudentExamID IS NOT NULL THEN c.CourseID END) AS DECIMAL(5,2)) / COUNT(DISTINCT c.CourseID) * 100
                            ELSE 0 
                        END AS CompletionRate
                    FROM Users s
                    INNER JOIN Tracks t ON s.TrackID = t.TrackID
                    INNER JOIN TrackCourses tc ON t.TrackID = tc.TrackID
                    INNER JOIN Courses c ON tc.CourseID = c.CourseID
                    LEFT JOIN Exams e ON e.TrackCourseID = tc.TrackCourseID
                    LEFT JOIN StudentExams se ON s.UserID = se.StudentID AND e.ExamID = se.ExamID
                    WHERE t.TrackID = @TrackID AND s.BranchID = @BranchID
                    GROUP BY s.UserID, s.FullName
                    ORDER BY AverageScore DESC;

                    -- Get track statistics
                    SELECT 
                        COUNT(DISTINCT s.UserID) AS TotalStudents,
                        COUNT(DISTINCT c.CourseID) AS TotalCourses,
                        COUNT(DISTINCT e.ExamID) AS TotalExams,
                        AVG(CAST(se.Score AS DECIMAL(5,2))) AS AverageScore,
                        AVG(CASE 
                            WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                            ELSE 0 
                        END) AS AveragePercentage,
                        CASE 
                            WHEN COUNT(se.StudentExamID) > 0 THEN 
                                CAST(SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS DECIMAL(5,2)) / COUNT(se.StudentExamID) * 100
                            ELSE 0 
                        END AS OverallPassRate,
                        CASE 
                            WHEN COUNT(DISTINCT c.CourseID) > 0 THEN 
                                CAST(COUNT(DISTINCT CASE WHEN se.StudentExamID IS NOT NULL THEN c.CourseID END) AS DECIMAL(5,2)) / COUNT(DISTINCT c.CourseID) * 100
                            ELSE 0 
                        END AS CourseCompletionRate
                    FROM Users s
                    INNER JOIN Tracks t ON s.TrackID = t.TrackID
                    INNER JOIN TrackCourses tc ON t.TrackID = tc.TrackID
                    INNER JOIN Courses c ON tc.CourseID = c.CourseID
                    LEFT JOIN Exams e ON e.TrackCourseID = tc.TrackCourseID
                    LEFT JOIN StudentExams se ON s.UserID = se.StudentID AND e.ExamID = se.ExamID
                    WHERE t.TrackID = @TrackID AND s.BranchID = @BranchID;
                END
            ");
            // GetTrackAllBranchesReport
            migrationBuilder.Sql(@"
                CREATE   PROCEDURE [dbo].[sp_GetTrackAllBranchesReport]
                    @TrackID INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Get track details
                    SELECT 
                        t.TrackID,
                        t.Name AS TrackName
                    FROM Tracks t
                    WHERE t.TrackID = @TrackID;

                    -- Get branch summaries
                    SELECT 
                        b.BranchID,
                        b.Name AS BranchName,
                        i.FullName AS ManagerName,
                        COUNT(DISTINCT s.UserID) AS TotalStudents,
                        COUNT(DISTINCT e.ExamID) AS TotalExams,
                        AVG(CAST(se.Score AS DECIMAL(5,2))) AS AverageScore,
                        CASE 
                            WHEN COUNT(se.StudentExamID) > 0 THEN 
                                CAST(SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS DECIMAL(5,2)) / COUNT(se.StudentExamID) * 100
                            ELSE 0 
                        END AS PassRate,
                        CASE 
                            WHEN COUNT(DISTINCT s.UserID) > 0 THEN 
                                AVG(CASE 
                                    WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                                    ELSE 0 
                                END)
                            ELSE 0 
                        END AS StudentPerformance
                    FROM Branches b
                    INNER JOIN BranchTracks bt ON b.BranchID = bt.BranchID
                    INNER JOIN Tracks t ON bt.TrackID = t.TrackID
                    LEFT JOIN Users i ON b.ManagerID = i.UserID
                    LEFT JOIN Users s ON s.BranchID = b.BranchID AND s.TrackID = t.TrackID
                    LEFT JOIN TrackCourses tc ON t.TrackID = tc.TrackID
                    LEFT JOIN Exams e ON e.TrackCourseID = tc.TrackCourseID
                    LEFT JOIN StudentExams se ON s.UserID = se.StudentID AND e.ExamID = se.ExamID
                    WHERE t.TrackID = @TrackID
                    GROUP BY b.BranchID, b.Name, i.FullName
                    ORDER BY StudentPerformance DESC;

                    -- Get overall statistics
                    SELECT 
                        COUNT(DISTINCT b.BranchID) AS TotalBranches,
                        COUNT(DISTINCT s.UserID) AS TotalStudents,
                        COUNT(DISTINCT e.ExamID) AS TotalExams,
                        AVG(CAST(se.Score AS DECIMAL(5,2))) AS AverageScore,
                        AVG(CASE 
                            WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                            ELSE 0 
                        END) AS AveragePercentage,
                        CASE 
                            WHEN COUNT(se.StudentExamID) > 0 THEN 
                                CAST(SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS DECIMAL(5,2)) / COUNT(se.StudentExamID) * 100
                            ELSE 0 
                        END AS OverallPassRate,
                        (SELECT TOP 1 b.Name 
                         FROM Branches b
                         INNER JOIN BranchTracks bt ON b.BranchID = bt.BranchID
                         INNER JOIN Tracks t ON bt.TrackID = t.TrackID
                         LEFT JOIN Users s ON s.BranchID = b.BranchID AND s.TrackID = t.TrackID
                         LEFT JOIN TrackCourses tc ON t.TrackID = tc.TrackID
                         LEFT JOIN Exams e ON e.TrackCourseID = tc.TrackCourseID
                         LEFT JOIN StudentExams se ON s.UserID = se.StudentID AND e.ExamID = se.ExamID
                         WHERE t.TrackID = @TrackID
                         GROUP BY b.BranchID, b.Name
                         ORDER BY AVG(CASE 
                             WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                             ELSE 0 
                         END) DESC) AS BestPerformingBranch,
                        (SELECT TOP 1 b.Name 
                         FROM Branches b
                         INNER JOIN BranchTracks bt ON b.BranchID = bt.BranchID
                         INNER JOIN Tracks t ON bt.TrackID = t.TrackID
                         LEFT JOIN Users s ON s.BranchID = b.BranchID AND s.TrackID = t.TrackID
                         LEFT JOIN TrackCourses tc ON t.TrackID = tc.TrackID
                         LEFT JOIN Exams e ON e.TrackCourseID = tc.TrackCourseID
                         LEFT JOIN StudentExams se ON s.USerID = se.StudentID AND e.ExamID = se.ExamID
                         WHERE t.TrackID = @TrackID
                         GROUP BY b.BranchID, b.Name
                         ORDER BY AVG(CASE 
                             WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                             ELSE 0 
                         END) ASC) AS WorstPerformingBranch
                    FROM Branches b
                    INNER JOIN BranchTracks bt ON b.BranchID = bt.BranchID
                    INNER JOIN Tracks t ON bt.TrackID = t.TrackID
                    LEFT JOIN Users s ON s.BranchID = b.BranchID AND s.TrackID = t.TrackID
                    LEFT JOIN TrackCourses tc ON t.TrackID = tc.TrackCourseID
                    LEFT JOIN Exams e ON e.TrackCourseID = tc.TrackCourseID
                    LEFT JOIN StudentExams se ON s.UserID = se.StudentID AND e.ExamID = se.ExamID
                    WHERE t.TrackID = @TrackID;
                END
            ");
            // GetStudentInstructorExamsReport
            migrationBuilder.Sql(@"
                CREATE   PROCEDURE [dbo].[sp_GetStudentInstructorExamsReport]
                    @StudentID INT,
                    @InstructorID INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Get student and instructor details
                    SELECT 
                        s.UserID AS StudentID,
                        s.FullName AS StudentName,
                        i.UserID AS IntructorID,
                        i.FullName AS InstructorName
                    FROM Users s
                    CROSS JOIN Users i
                    WHERE s.UserID = @StudentID AND i.UserID = @InstructorID;

                    -- Get exam summaries for this instructor
                    SELECT 
                        e.ExamID,
                        e.Title AS ExamTitle,
                        c.Name AS CourseName,
                        e.ScheduledAt,
                        se.StartedAt,
                        se.SubmittedAt,
                        se.Score,
                        e.FullMark,
                        CASE 
                            WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                            ELSE 0 
                        END AS Percentage,
                        CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END AS IsPassed,
                        e.Status AS ExamStatus
                    FROM StudentExams se
                    INNER JOIN Exams e ON se.ExamID = e.ExamID
                    INNER JOIN TrackCourses tc ON e.TrackCourseID = tc.TrackCourseID
                    INNER JOIN Courses c ON tc.CourseID = c.CourseID
                    INNER JOIN InstructorCourses ic ON c.CourseID = ic.CourseID
                    WHERE se.StudentID = @StudentID 
                      AND ic.InstructorID = @InstructorID
                    ORDER BY e.ScheduledAt DESC;

                    -- Get performance summary for this instructor
                    SELECT 
                        COUNT(*) AS TotalExams,
                        SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS PassedExams,
                        SUM(CASE WHEN se.Score < e.PassMark THEN 1 ELSE 0 END) AS FailedExams,
                        AVG(CAST(se.Score AS DECIMAL(5,2))) AS AverageScore,
                        AVG(CASE 
                            WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                            ELSE 0 
                        END) AS AveragePercentage,
                        MAX(se.Score) AS HighestScore,
                        MIN(se.Score) AS LowestScore,
                        CASE 
                            WHEN COUNT(*) > 0 THEN 
                                CAST(SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS DECIMAL(5,2)) / COUNT(*) * 100
                            ELSE 0 
                        END AS PassRate
                    FROM StudentExams se
                    INNER JOIN Exams e ON se.ExamID = e.ExamID
                    INNER JOIN TrackCourses tc ON e.TrackCourseID = tc.TrackCourseID
                    INNER JOIN Courses c ON tc.CourseID = c.CourseID
                    INNER JOIN InstructorCourses ic ON c.CourseID = ic.CourseID
                    WHERE se.StudentID = @StudentID 
                      AND ic.InstructorID = @InstructorID;
                END
            ");
            // sp_GetStudentExamReport
            migrationBuilder.Sql(@"
                CREATE   PROCEDURE [dbo].[sp_GetStudentExamReport]
                    @StudentExamID INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Get exam details
                    SELECT 
                        se.StudentExamID,
                        s.UserID AS StudentID,
                        s.FullName AS StudentName,
                        s.Email AS StudentEmail,
                        e.ExamID,
                        e.Title AS ExamTitle,
                        c.Name AS CourseName,
                        t.Name AS TrackName,
                        b.Name AS BranchName,
                        e.ScheduledAt,
                        se.StartedAt,
                        se.SubmittedAt,
                        e.DurationMinutes,
                        se.Score,
                        e.FullMark,
                        e.PassMark,
                        CASE 
                            WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                            ELSE 0 
                        END AS Percentage,
                        CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END AS IsPassed,
                        e.Status AS ExamStatus
                    FROM StudentExams se
                    INNER JOIN Users s ON se.StudentID = s.UserID
                    INNER JOIN Exams e ON se.ExamID = e.ExamID
                    INNER JOIN TrackCourses tc ON e.TrackCourseID = tc.TrackCourseID
                    INNER JOIN Courses c ON tc.CourseID = c.CourseID
                    INNER JOIN Tracks t ON tc.TrackID = t.TrackID
                    INNER JOIN BranchTracks bt ON t.TrackID = bt.TrackID
                    INNER JOIN Branches b ON bt.BranchID = b.BranchID
                    WHERE se.StudentExamID = @StudentExamID;

                    -- Get question answers
                    SELECT 
                        q.QuestionID,
                        q.Body AS QuestionBody,
                        q.Type AS QuestionType,
                        q.Marks AS QuestionMarks,
                        a.AnswerID,
                        a.Body AS AnswerText,
                        a.IsCorrect,
                        CASE WHEN sa.AnswerID IS NOT NULL THEN 1 ELSE 0 END AS IsSelected,
                        CASE 
                            WHEN q.Type IN ('TrueFalse', 'ChooseOne') THEN 
                                CASE WHEN a.IsCorrect = 1 AND sa.AnswerID IS NOT NULL THEN q.Marks ELSE 0 END
                            WHEN q.Type = 'ChooseAll' THEN
                                -- This would need more complex logic for ChooseAll questions
                                0
                            ELSE 0
                        END AS EarnedMarks
                    FROM Questions q
                    INNER JOIN ExamQuestions eq ON q.QuestionID = eq.QuestionID
                    INNER JOIN Exams e ON eq.ExamID = e.ExamID
                    INNER JOIN StudentExams se ON e.ExamID = se.ExamID
                    LEFT JOIN Answers a ON q.QuestionID = a.QuestionID
                    LEFT JOIN StudentAnswers sa ON a.AnswerID = sa.AnswerID AND sa.StudentExamID = se.StudentExamID
                    WHERE se.StudentExamID = @StudentExamID
                    ORDER BY q.QuestionID, a.AnswerID;
                END
            ");
            // GetStudentCourseExamsReport
            migrationBuilder.Sql(@"
                CREATE   PROCEDURE [dbo].[sp_GetStudentCourseExamsReport]
                    @StudentID INT,
                    @CourseID INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Get student and course details
                    SELECT 
                        s.UserID AS StudentID,
                        s.FullName AS StudentName,
                        c.CourseID,
                        c.Name AS CourseName,
                        i.FullName AS InstructorName
                    FROM Users s
                    INNER JOIN Courses c ON c.CourseID = @CourseID
                    LEFT JOIN InstructorCourses ic ON c.CourseID = ic.CourseID
                    LEFT JOIN Users i ON ic.InstructorID = i.UserID
                    WHERE s.UserID = @StudentID;

                    -- Get exam summaries for this course
                    SELECT 
                        e.ExamID,
                        e.Title AS ExamTitle,
                        c.Name AS CourseName,
                        e.ScheduledAt,
                        se.StartedAt,
                        se.SubmittedAt,
                        se.Score,
                        e.FullMark,
                        CASE 
                            WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                            ELSE 0 
                        END AS Percentage,
                        CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END AS IsPassed,
                        e.Status AS ExamStatus
                    FROM StudentExams se
                    INNER JOIN Exams e ON se.ExamID = e.ExamID
                    INNER JOIN TrackCourses tc ON e.TrackCourseID = tc.TrackCourseID
                    INNER JOIN Courses c ON tc.CourseID = c.CourseID
                    WHERE se.StudentID = @StudentID 
                      AND c.CourseID = @CourseID
                    ORDER BY e.ScheduledAt DESC;

                    -- Get performance summary for this course
                    SELECT 
                        COUNT(*) AS TotalExams,
                        SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS PassedExams,
                        SUM(CASE WHEN se.Score < e.PassMark THEN 1 ELSE 0 END) AS FailedExams,
                        AVG(CAST(se.Score AS DECIMAL(5,2))) AS AverageScore,
                        AVG(CASE 
                            WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                            ELSE 0 
                        END) AS AveragePercentage,
                        MAX(se.Score) AS HighestScore,
                        MIN(se.Score) AS LowestScore,
                        CASE 
                            WHEN COUNT(*) > 0 THEN 
                                CAST(SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS DECIMAL(5,2)) / COUNT(*) * 100
                            ELSE 0 
                        END AS PassRate
                    FROM StudentExams se
                    INNER JOIN Exams e ON se.ExamID = e.ExamID
                    INNER JOIN TrackCourses tc ON e.TrackCourseID = tc.TrackCourseID
                    INNER JOIN Courses c ON tc.CourseID = c.CourseID
                    WHERE se.StudentID = @StudentID 
                      AND c.CourseID = @CourseID;
                END
            ");
            // sp_GetStudentAllExamsReport
            migrationBuilder.Sql(@"
                CREATE   PROCEDURE [dbo].[sp_GetStudentAllExamsReport]
                    @StudentID INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Get student details
                    SELECT 
                        s.UserID As StudentID,
                        s.FullName AS StudentName,
                        s.Email AS StudentEmail,
                        t.Name AS TrackName,
                        b.Name AS BranchName
                    FROM Users s
                    INNER JOIN Tracks t ON s.TrackID = t.TrackID
                    INNER JOIN BranchTracks bt ON t.TrackID = bt.TrackID and bt.BranchID = s.BranchID
                    INNER JOIN Branches b ON bt.BranchID = b.BranchID
                    WHERE s.UserID = @StudentID;

                    -- Get exam summaries
                    SELECT 
                        e.ExamID,
                        e.Title AS ExamTitle,
                        c.Name AS CourseName,
                        e.ScheduledAt,
                        se.StartedAt,
                        se.SubmittedAt,
                        se.Score,
                        e.FullMark,
                        CASE 
                            WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                            ELSE 0 
                        END AS Percentage,
                        CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END AS IsPassed,
                        e.Status AS ExamStatus
                    FROM StudentExams se
                    INNER JOIN Exams e ON se.ExamID = e.ExamID
                    INNER JOIN TrackCourses tc ON e.TrackCourseID = tc.TrackCourseID
                    INNER JOIN Courses c ON tc.CourseID = c.CourseID
                    WHERE se.StudentID = @StudentID
                    ORDER BY e.ScheduledAt DESC;

                    -- Get performance summary
                    SELECT 
                        COUNT(*) AS TotalExams,
                        SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS PassedExams,
                        SUM(CASE WHEN se.Score < e.PassMark THEN 1 ELSE 0 END) AS FailedExams,
                        AVG(CAST(se.Score AS DECIMAL(5,2))) AS AverageScore,
                        AVG(CASE 
                            WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                            ELSE 0 
                        END) AS AveragePercentage,
                        MAX(se.Score) AS HighestScore,
                        MIN(se.Score) AS LowestScore,
                        CASE 
                            WHEN COUNT(*) > 0 THEN 
                                CAST(SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS DECIMAL(5,2)) / COUNT(*) * 100
                            ELSE 0 
                        END AS PassRate
                    FROM StudentExams se
                    INNER JOIN Exams e ON se.ExamID = e.ExamID
                    WHERE se.StudentID = @StudentID;
                END
            ");
            // GetInstructorCourseReport
            migrationBuilder.Sql(@"
                CREATE   PROCEDURE [dbo].[sp_GetInstructorCourseReport]
                    @InstructorID INT,
                    @CourseID INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Get instructor and course details
                    SELECT 
                        i.UserID AS InstructorID,
                        i.FullName AS InstructorName,
                        c.CourseID,
                        c.Name AS CourseName,
                        t.Name AS TrackName
                    FROM Users i
                    INNER JOIN InstructorCourses ic ON i.UserID = ic.InstructorID
                    INNER JOIN Courses c ON ic.CourseID = c.CourseID
                    INNER JOIN TrackCourses tc ON c.CourseID = tc.CourseID
                    INNER JOIN Tracks t ON tc.TrackID = t.TrackID
                    WHERE i.UserID = @InstructorID AND c.CourseID = @CourseID;

                    -- Get exams for this course
                    SELECT 
                        e.ExamID,
                        e.Title AS ExamTitle,
                        e.ScheduledAt,
                        e.DurationMinutes,
                        e.FullMark,
                        e.PassMark,
                        e.Status AS ExamStatus,
                        COUNT(DISTINCT s.UserID) AS TotalStudents,
                        COUNT(se.StudentExamID) AS StudentsAttempted,
                        AVG(CAST(se.Score AS DECIMAL(5,2))) AS AverageScore,
                        CASE 
                            WHEN COUNT(se.StudentExamID) > 0 THEN 
                                CAST(SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS DECIMAL(5,2)) / COUNT(se.StudentExamID) * 100
                            ELSE 0 
                        END AS PassRate
                    FROM Exams e
                    INNER JOIN TrackCourses tc ON e.TrackCourseID = tc.TrackCourseID
                    INNER JOIN Courses c ON tc.CourseID = c.CourseID
                    LEFT JOIN Users s ON s.TrackID = tc.TrackID
                    LEFT JOIN StudentExams se ON s.UserID = se.StudentID AND e.ExamID = se.ExamID
                    WHERE c.CourseID = @CourseID
                    GROUP BY e.ExamID, e.Title, e.ScheduledAt, e.DurationMinutes, e.FullMark, e.PassMark, e.Status
                    ORDER BY e.ScheduledAt DESC;

                    -- Get student performances
                    SELECT 
                        s.UserID AS StudentID,
                        s.FullName AS StudentName,
                        COUNT(se.StudentExamID) AS TotalExams,
                        SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS PassedExams,
                        AVG(CAST(se.Score AS DECIMAL(5,2))) AS AverageScore,
                        AVG(CASE 
                            WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                            ELSE 0 
                        END) AS AveragePercentage,
                        CASE 
                            WHEN COUNT(se.StudentExamID) > 0 THEN 
                                CAST(SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS DECIMAL(5,2)) / COUNT(se.StudentExamID) * 100
                            ELSE 0 
                        END AS PassRate
                    FROM Users s
                    INNER JOIN TrackCourses tc ON s.TrackID = tc.TrackID
                    INNER JOIN Courses c ON tc.CourseID = c.CourseID
                    LEFT JOIN Exams e ON e.TrackCourseID = tc.TrackCourseID
                    LEFT JOIN StudentExams se ON s.UserID = se.StudentID AND e.ExamID = se.ExamID
                    WHERE c.CourseID = @CourseID
                    GROUP BY s.UserID, s.FullName
                    ORDER BY AverageScore DESC;

                    -- Get course statistics
                    SELECT 
                        COUNT(DISTINCT s.UserID) AS TotalStudents,
                        COUNT(DISTINCT e.ExamID) AS TotalExams,
                        COUNT(se.StudentExamID) AS CompletedExams,
                        AVG(CAST(se.Score AS DECIMAL(5,2))) AS AverageScore,
                        AVG(CASE 
                            WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                            ELSE 0 
                        END) AS AveragePercentage,
                        CASE 
                            WHEN COUNT(se.StudentExamID) > 0 THEN 
                                CAST(SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS DECIMAL(5,2)) / COUNT(se.StudentExamID) * 100
                            ELSE 0 
                        END AS OverallPassRate,
                        MAX(se.Score) AS HighestScore,
                        MIN(se.Score) AS LowestScore
                    FROM Users s
                    INNER JOIN TrackCourses tc ON s.TrackID = tc.TrackID
                    INNER JOIN Courses c ON tc.CourseID = c.CourseID
                    LEFT JOIN Exams e ON e.TrackCourseID = tc.TrackCourseID
                    LEFT JOIN StudentExams se ON s.UserID = se.StudentID AND e.ExamID = se.ExamID
                    WHERE c.CourseID = @CourseID;
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_CalculateStudentExamScore");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetStudentExamReport");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetStudentAllExamsReport");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetStudentInstructorExamsReport");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetStudentCourseExamsReport");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetExamStudentsReport");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetInstructorCourseReport");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetTrackBranchReport");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetTrackAllBranchesReport");
        }
    }
}