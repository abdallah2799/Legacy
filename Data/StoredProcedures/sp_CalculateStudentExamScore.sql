CREATE PROCEDURE sp_CalculateStudentExamScore
    @StudentExamId INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @TotalScore INT = 0;
    DECLARE @StudentId INT;
    DECLARE @ExamId INT;
    
    -- Get student and exam IDs
    SELECT @StudentId = StudentId, @ExamId = ExamId
    FROM StudentExams
    WHERE StudentExamId = @StudentExamId;
    
    IF @StudentId IS NULL
    BEGIN
        RAISERROR('StudentExam with ID %d not found', 16, 1, @StudentExamId);
        RETURN;
    END
    
    -- Calculate total score by summing marks from correct answers
    SELECT @TotalScore = ISNULL(SUM(q.Marks), 0)
    FROM StudentAnswers sa
    INNER JOIN Questions q ON sa.QuestionId = q.QuestionId
    INNER JOIN Answers a ON sa.AnswerId = a.AnswerId
    WHERE sa.StudentExamId = @StudentExamId
      AND sa.IsCorrect = 1
      AND a.IsCorrect = 1;
    
    -- Update the StudentExam with calculated score
    UPDATE StudentExams
    SET Score = @TotalScore,
        SubmittedAt = CASE 
            WHEN SubmittedAt IS NULL THEN GETUTCDATE()
            ELSE SubmittedAt
        END
    WHERE StudentExamId = @StudentExamId;
    
    -- Return the calculated score
    SELECT @TotalScore AS CalculatedScore;
END
