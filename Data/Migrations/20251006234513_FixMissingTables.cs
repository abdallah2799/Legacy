using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FixMissingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__ExamQues__F9A9275FF8348650",
                table: "ExamQuestions");

            migrationBuilder.RenameTable(
                name: "StudentExam",
                newName: "StudentExams");

            migrationBuilder.RenameTable(
                name: "StudentAnswer",
                newName: "StudentAnswers");

            migrationBuilder.RenameTable(
                name: "InstructorCourse",
                newName: "InstructorCourses");

            migrationBuilder.RenameTable(
                name: "Answer",
                newName: "Answers");

            migrationBuilder.RenameColumn(
                name: "QuestionID",
                table: "ExamQuestions",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "ExamID",
                table: "ExamQuestions",
                newName: "ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestions_QuestionID",
                table: "ExamQuestions",
                newName: "IX_ExamQuestions_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExam_StudentID",
                table: "StudentExams",
                newName: "IX_StudentExams_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExam_ExamID",
                table: "StudentExams",
                newName: "IX_StudentExams_ExamID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAnswer_StudentExamID",
                table: "StudentAnswers",
                newName: "IX_StudentAnswers_StudentExamID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAnswer_QuestionID",
                table: "StudentAnswers",
                newName: "IX_StudentAnswers_QuestionID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAnswer_AnswerID",
                table: "StudentAnswers",
                newName: "IX_StudentAnswers_AnswerID");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorCourse_InstructorID",
                table: "InstructorCourses",
                newName: "IX_InstructorCourses_InstructorID");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorCourse_CourseID",
                table: "InstructorCourses",
                newName: "IX_InstructorCourses_CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_QuestionID",
                table: "Answers",
                newName: "IX_Answers_QuestionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestions",
                table: "ExamQuestions",
                columns: new[] { "ExamId", "QuestionId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestions",
                table: "ExamQuestions");

            migrationBuilder.RenameTable(
                name: "StudentExams",
                newName: "StudentExam");

            migrationBuilder.RenameTable(
                name: "StudentAnswers",
                newName: "StudentAnswer");

            migrationBuilder.RenameTable(
                name: "InstructorCourses",
                newName: "InstructorCourse");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "Answer");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "ExamQuestions",
                newName: "QuestionID");

            migrationBuilder.RenameColumn(
                name: "ExamId",
                table: "ExamQuestions",
                newName: "ExamID");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestions_QuestionId",
                table: "ExamQuestions",
                newName: "IX_ExamQuestions_QuestionID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExams_StudentID",
                table: "StudentExam",
                newName: "IX_StudentExam_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentExams_ExamID",
                table: "StudentExam",
                newName: "IX_StudentExam_ExamID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAnswers_StudentExamID",
                table: "StudentAnswer",
                newName: "IX_StudentAnswer_StudentExamID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAnswers_QuestionID",
                table: "StudentAnswer",
                newName: "IX_StudentAnswer_QuestionID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAnswers_AnswerID",
                table: "StudentAnswer",
                newName: "IX_StudentAnswer_AnswerID");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorCourses_InstructorID",
                table: "InstructorCourse",
                newName: "IX_InstructorCourse_InstructorID");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorCourses_CourseID",
                table: "InstructorCourse",
                newName: "IX_InstructorCourse_CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionID",
                table: "Answer",
                newName: "IX_Answer_QuestionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ExamQues__F9A9275FF8348650",
                table: "ExamQuestions",
                columns: new[] { "ExamID", "QuestionID" });
        }
    }
}
