-- =============================================
-- Report Stored Procedures for Examination System
-- =============================================

-- 1. Single student in single exam report
CREATE OR ALTER PROCEDURE sp_GetStudentExamReport
    @StudentExamID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Get exam details
    SELECT 
        se.StudentExamID,
        s.StudentID,
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
    FROM StudentExam se
    INNER JOIN Student s ON se.StudentID = s.StudentID
    INNER JOIN Exam e ON se.ExamID = e.ExamID
    INNER JOIN TrackCourse tc ON e.TrackCourseID = tc.TrackCourseID
    INNER JOIN Course c ON tc.CourseID = c.CourseID
    INNER JOIN Track t ON tc.TrackID = t.TrackID
    INNER JOIN BranchTrack bt ON t.TrackID = bt.TrackID
    INNER JOIN Branch b ON bt.BranchID = b.BranchID
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
    INNER JOIN ExamQuestion eq ON q.QuestionID = eq.QuestionID
    INNER JOIN Exam e ON eq.ExamID = e.ExamID
    INNER JOIN StudentExam se ON e.ExamID = se.ExamID
    LEFT JOIN Answers a ON q.QuestionID = a.QuestionID
    LEFT JOIN StudentAnswer sa ON a.AnswerID = sa.AnswerID AND sa.StudentExamID = se.StudentExamID
    WHERE se.StudentExamID = @StudentExamID
    ORDER BY q.QuestionID, a.AnswerID;
END;
GO

-- 2. Single student in all exams report
CREATE OR ALTER PROCEDURE sp_GetStudentAllExamsReport
    @StudentID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Get student details
    SELECT 
        s.StudentID,
        s.FullName AS StudentName,
        s.Email AS StudentEmail,
        t.Name AS TrackName,
        b.Name AS BranchName
    FROM Student s
    INNER JOIN Track t ON s.TrackID = t.TrackID
    INNER JOIN BranchTrack bt ON t.TrackID = bt.TrackID
    INNER JOIN Branch b ON bt.BranchID = b.BranchID
    WHERE s.StudentID = @StudentID;

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
    FROM StudentExam se
    INNER JOIN Exam e ON se.ExamID = e.ExamID
    INNER JOIN TrackCourse tc ON e.TrackCourseID = tc.TrackCourseID
    INNER JOIN Course c ON tc.CourseID = c.CourseID
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
    FROM StudentExam se
    INNER JOIN Exam e ON se.ExamID = e.ExamID
    WHERE se.StudentID = @StudentID;
END;
GO

-- 3. Single student in all exams by specific instructor
CREATE OR ALTER PROCEDURE sp_GetStudentInstructorExamsReport
    @StudentID INT,
    @InstructorID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Get student and instructor details
    SELECT 
        s.StudentID,
        s.FullName AS StudentName,
        i.InstructorID,
        i.FullName AS InstructorName
    FROM Student s
    CROSS JOIN Instructor i
    WHERE s.StudentID = @StudentID AND i.InstructorID = @InstructorID;

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
    FROM StudentExam se
    INNER JOIN Exam e ON se.ExamID = e.ExamID
    INNER JOIN TrackCourse tc ON e.TrackCourseID = tc.TrackCourseID
    INNER JOIN Course c ON tc.CourseID = c.CourseID
    INNER JOIN InstructorCourse ic ON c.CourseID = ic.CourseID
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
    FROM StudentExam se
    INNER JOIN Exam e ON se.ExamID = e.ExamID
    INNER JOIN TrackCourse tc ON e.TrackCourseID = tc.TrackCourseID
    INNER JOIN Course c ON tc.CourseID = c.CourseID
    INNER JOIN InstructorCourse ic ON c.CourseID = ic.CourseID
    WHERE se.StudentID = @StudentID 
      AND ic.InstructorID = @InstructorID;
END;
GO

-- 4. Single student in all exams in specific course
CREATE OR ALTER PROCEDURE sp_GetStudentCourseExamsReport
    @StudentID INT,
    @CourseID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Get student and course details
    SELECT 
        s.StudentID,
        s.FullName AS StudentName,
        c.CourseID,
        c.Name AS CourseName,
        i.FullName AS InstructorName
    FROM Student s
    INNER JOIN Course c ON c.CourseID = @CourseID
    LEFT JOIN InstructorCourse ic ON c.CourseID = ic.CourseID
    LEFT JOIN Instructor i ON ic.InstructorID = i.InstructorID
    WHERE s.StudentID = @StudentID;

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
    FROM StudentExam se
    INNER JOIN Exam e ON se.ExamID = e.ExamID
    INNER JOIN TrackCourse tc ON e.TrackCourseID = tc.TrackCourseID
    INNER JOIN Course c ON tc.CourseID = c.CourseID
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
    FROM StudentExam se
    INNER JOIN Exam e ON se.ExamID = e.ExamID
    INNER JOIN TrackCourse tc ON e.TrackCourseID = tc.TrackCourseID
    INNER JOIN Course c ON tc.CourseID = c.CourseID
    WHERE se.StudentID = @StudentID 
      AND c.CourseID = @CourseID;
END;
GO

-- 5. Single exam showing all students performance
CREATE OR ALTER PROCEDURE sp_GetExamStudentsReport
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
    FROM Exam e
    INNER JOIN TrackCourse tc ON e.TrackCourseID = tc.TrackCourseID
    INNER JOIN Course c ON tc.CourseID = c.CourseID
    LEFT JOIN InstructorCourse ic ON c.CourseID = ic.CourseID
    LEFT JOIN Instructor i ON ic.InstructorID = i.InstructorID
    WHERE e.ExamID = @ExamID;

    -- Get student results
    SELECT 
        s.StudentID,
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
    FROM StudentExam se
    INNER JOIN Student s ON se.StudentID = s.StudentID
    INNER JOIN Exam e ON se.ExamID = e.ExamID
    WHERE se.ExamID = @ExamID
    ORDER BY se.Score DESC, s.FullName;

    -- Get exam statistics
    SELECT 
        COUNT(DISTINCT s.StudentID) AS TotalStudents,
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
            WHEN COUNT(DISTINCT s.StudentID) > 0 THEN 
                CAST(COUNT(se.StudentExamID) AS DECIMAL(5,2)) / COUNT(DISTINCT s.StudentID) * 100
            ELSE 0 
        END AS AttemptRate
    FROM Student s
    INNER JOIN TrackCourse tc ON s.TrackID = tc.TrackID
    INNER JOIN Course c ON tc.CourseID = c.CourseID
    INNER JOIN Exam e ON e.TrackCourseID = tc.TrackCourseID
    LEFT JOIN StudentExam se ON s.StudentID = se.StudentID AND e.ExamID = se.ExamID
    WHERE e.ExamID = @ExamID;
END;
GO

-- 6. Single course by specific instructor
CREATE OR ALTER PROCEDURE sp_GetInstructorCourseReport
    @InstructorID INT,
    @CourseID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Get instructor and course details
    SELECT 
        i.InstructorID,
        i.FullName AS InstructorName,
        c.CourseID,
        c.Name AS CourseName,
        t.Name AS TrackName
    FROM Instructor i
    INNER JOIN InstructorCourse ic ON i.InstructorID = ic.InstructorID
    INNER JOIN Course c ON ic.CourseID = c.CourseID
    INNER JOIN TrackCourse tc ON c.CourseID = tc.CourseID
    INNER JOIN Track t ON tc.TrackID = t.TrackID
    WHERE i.InstructorID = @InstructorID AND c.CourseID = @CourseID;

    -- Get exams for this course
    SELECT 
        e.ExamID,
        e.Title AS ExamTitle,
        e.ScheduledAt,
        e.DurationMinutes,
        e.FullMark,
        e.PassMark,
        e.Status AS ExamStatus,
        COUNT(DISTINCT s.StudentID) AS TotalStudents,
        COUNT(se.StudentExamID) AS StudentsAttempted,
        AVG(CAST(se.Score AS DECIMAL(5,2))) AS AverageScore,
        CASE 
            WHEN COUNT(se.StudentExamID) > 0 THEN 
                CAST(SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS DECIMAL(5,2)) / COUNT(se.StudentExamID) * 100
            ELSE 0 
        END AS PassRate
    FROM Exam e
    INNER JOIN TrackCourse tc ON e.TrackCourseID = tc.TrackCourseID
    INNER JOIN Course c ON tc.CourseID = c.CourseID
    LEFT JOIN Student s ON s.TrackID = tc.TrackID
    LEFT JOIN StudentExam se ON s.StudentID = se.StudentID AND e.ExamID = se.ExamID
    WHERE c.CourseID = @CourseID
    GROUP BY e.ExamID, e.Title, e.ScheduledAt, e.DurationMinutes, e.FullMark, e.PassMark, e.Status
    ORDER BY e.ScheduledAt DESC;

    -- Get student performances
    SELECT 
        s.StudentID,
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
    FROM Student s
    INNER JOIN TrackCourse tc ON s.TrackID = tc.TrackID
    INNER JOIN Course c ON tc.CourseID = c.CourseID
    LEFT JOIN Exam e ON e.TrackCourseID = tc.TrackCourseID
    LEFT JOIN StudentExam se ON s.StudentID = se.StudentID AND e.ExamID = se.ExamID
    WHERE c.CourseID = @CourseID
    GROUP BY s.StudentID, s.FullName
    ORDER BY AverageScore DESC;

    -- Get course statistics
    SELECT 
        COUNT(DISTINCT s.StudentID) AS TotalStudents,
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
    FROM Student s
    INNER JOIN TrackCourse tc ON s.TrackID = tc.TrackID
    INNER JOIN Course c ON tc.CourseID = c.CourseID
    LEFT JOIN Exam e ON e.TrackCourseID = tc.TrackCourseID
    LEFT JOIN StudentExam se ON s.StudentID = se.StudentID AND e.ExamID = se.ExamID
    WHERE c.CourseID = @CourseID;
END;
GO

-- 7. Single track in a branch
CREATE OR ALTER PROCEDURE sp_GetTrackBranchReport
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
    FROM Track t
    INNER JOIN BranchTrack bt ON t.TrackID = bt.TrackID
    INNER JOIN Branch b ON bt.BranchID = b.BranchID
    LEFT JOIN Instructor i ON bt.SupervisorID = i.InstructorID
    WHERE t.TrackID = @TrackID AND b.BranchID = @BranchID;

    -- Get courses in this track
    SELECT 
        c.CourseID,
        c.Name AS CourseName,
        i.FullName AS InstructorName,
        COUNT(DISTINCT e.ExamID) AS TotalExams,
        COUNT(DISTINCT s.StudentID) AS TotalStudents,
        AVG(CAST(se.Score AS DECIMAL(5,2))) AS AverageScore,
        CASE 
            WHEN COUNT(se.StudentExamID) > 0 THEN 
                CAST(SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS DECIMAL(5,2)) / COUNT(se.StudentExamID) * 100
            ELSE 0 
        END AS PassRate
    FROM Course c
    INNER JOIN TrackCourse tc ON c.CourseID = tc.CourseID
    INNER JOIN Track t ON tc.TrackID = t.TrackID
    LEFT JOIN InstructorCourse ic ON c.CourseID = ic.CourseID
    LEFT JOIN Instructor i ON ic.InstructorID = i.InstructorID
    LEFT JOIN Exam e ON e.TrackCourseID = tc.TrackCourseID
    LEFT JOIN Student s ON s.TrackID = t.TrackID
    LEFT JOIN StudentExam se ON s.StudentID = se.StudentID AND e.ExamID = se.ExamID
    WHERE t.TrackID = @TrackID
    GROUP BY c.CourseID, c.Name, i.FullName
    ORDER BY c.Name;

    -- Get student performances
    SELECT 
        s.StudentID,
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
    FROM Student s
    INNER JOIN Track t ON s.TrackID = t.TrackID
    INNER JOIN TrackCourse tc ON t.TrackID = tc.TrackID
    INNER JOIN Course c ON tc.CourseID = c.CourseID
    LEFT JOIN Exam e ON e.TrackCourseID = tc.TrackCourseID
    LEFT JOIN StudentExam se ON s.StudentID = se.StudentID AND e.ExamID = se.ExamID
    WHERE t.TrackID = @TrackID AND s.BranchID = @BranchID
    GROUP BY s.StudentID, s.FullName
    ORDER BY AverageScore DESC;

    -- Get track statistics
    SELECT 
        COUNT(DISTINCT s.StudentID) AS TotalStudents,
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
    FROM Student s
    INNER JOIN Track t ON s.TrackID = t.TrackID
    INNER JOIN TrackCourse tc ON t.TrackID = tc.TrackID
    INNER JOIN Course c ON tc.CourseID = c.CourseID
    LEFT JOIN Exam e ON e.TrackCourseID = tc.TrackCourseID
    LEFT JOIN StudentExam se ON s.StudentID = se.StudentID AND e.ExamID = se.ExamID
    WHERE t.TrackID = @TrackID AND s.BranchID = @BranchID;
END;
GO

-- 8. Single track over all branches
CREATE OR ALTER PROCEDURE sp_GetTrackAllBranchesReport
    @TrackID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Get track details
    SELECT 
        t.TrackID,
        t.Name AS TrackName
    FROM Track t
    WHERE t.TrackID = @TrackID;

    -- Get branch summaries
    SELECT 
        b.BranchID,
        b.Name AS BranchName,
        i.FullName AS ManagerName,
        COUNT(DISTINCT s.StudentID) AS TotalStudents,
        COUNT(DISTINCT e.ExamID) AS TotalExams,
        AVG(CAST(se.Score AS DECIMAL(5,2))) AS AverageScore,
        CASE 
            WHEN COUNT(se.StudentExamID) > 0 THEN 
                CAST(SUM(CASE WHEN se.Score >= e.PassMark THEN 1 ELSE 0 END) AS DECIMAL(5,2)) / COUNT(se.StudentExamID) * 100
            ELSE 0 
        END AS PassRate,
        CASE 
            WHEN COUNT(DISTINCT s.StudentID) > 0 THEN 
                AVG(CASE 
                    WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
                    ELSE 0 
                END)
            ELSE 0 
        END AS StudentPerformance
    FROM Branch b
    INNER JOIN BranchTrack bt ON b.BranchID = bt.BranchID
    INNER JOIN Track t ON bt.TrackID = t.TrackID
    LEFT JOIN Instructor i ON b.ManagerID = i.InstructorID
    LEFT JOIN Student s ON s.BranchID = b.BranchID AND s.TrackID = t.TrackID
    LEFT JOIN TrackCourse tc ON t.TrackID = tc.TrackID
    LEFT JOIN Exam e ON e.TrackCourseID = tc.TrackCourseID
    LEFT JOIN StudentExam se ON s.StudentID = se.StudentID AND e.ExamID = se.ExamID
    WHERE t.TrackID = @TrackID
    GROUP BY b.BranchID, b.Name, i.FullName
    ORDER BY StudentPerformance DESC;

    -- Get overall statistics
    SELECT 
        COUNT(DISTINCT b.BranchID) AS TotalBranches,
        COUNT(DISTINCT s.StudentID) AS TotalStudents,
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
         FROM Branch b
         INNER JOIN BranchTrack bt ON b.BranchID = bt.BranchID
         INNER JOIN Track t ON bt.TrackID = t.TrackID
         LEFT JOIN Student s ON s.BranchID = b.BranchID AND s.TrackID = t.TrackID
         LEFT JOIN TrackCourse tc ON t.TrackID = tc.TrackID
         LEFT JOIN Exam e ON e.TrackCourseID = tc.TrackCourseID
         LEFT JOIN StudentExam se ON s.StudentID = se.StudentID AND e.ExamID = se.ExamID
         WHERE t.TrackID = @TrackID
         GROUP BY b.BranchID, b.Name
         ORDER BY AVG(CASE 
             WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
             ELSE 0 
         END) DESC) AS BestPerformingBranch,
        (SELECT TOP 1 b.Name 
         FROM Branch b
         INNER JOIN BranchTrack bt ON b.BranchID = bt.BranchID
         INNER JOIN Track t ON bt.TrackID = t.TrackID
         LEFT JOIN Student s ON s.BranchID = b.BranchID AND s.TrackID = t.TrackID
         LEFT JOIN TrackCourse tc ON t.TrackID = tc.TrackID
         LEFT JOIN Exam e ON e.TrackCourseID = tc.TrackCourseID
         LEFT JOIN StudentExam se ON s.StudentID = se.StudentID AND e.ExamID = se.ExamID
         WHERE t.TrackID = @TrackID
         GROUP BY b.BranchID, b.Name
         ORDER BY AVG(CASE 
             WHEN e.FullMark > 0 THEN CAST(se.Score AS DECIMAL(5,2)) / e.FullMark * 100
             ELSE 0 
         END) ASC) AS WorstPerformingBranch
    FROM Branch b
    INNER JOIN BranchTrack bt ON b.BranchID = bt.BranchID
    INNER JOIN Track t ON bt.TrackID = t.TrackID
    LEFT JOIN Student s ON s.BranchID = b.BranchID AND s.TrackID = t.TrackID
    LEFT JOIN TrackCourse tc ON t.TrackID = tc.TrackID
    LEFT JOIN Exam e ON e.TrackCourseID = tc.TrackCourseID
    LEFT JOIN StudentExam se ON s.StudentID = se.StudentID AND e.ExamID = se.ExamID
    WHERE t.TrackID = @TrackID;
END;
GO
