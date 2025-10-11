🎓 Examination System – Updated Overview (2025 Edition)
🎯 Goal

نظام إدارة امتحانات متكامل متعدد الفروع (Branches) والتراكات (Tracks) على نمط ITI.
يدير الطلاب والمدرسين والإدمنز مع أدوار مميزة للمديرين (Branch Manager) والمشرفين (Track Supervisor).
يشمل إدارة السياسات الدراسية، الاختبارات، الدرجات، والمراجعات.

🧱 Architecture (Onion / Clean Architecture)
🟣 Core Layer

Purpose: Defines the domain model — the entities, enums, and interfaces — without implementation.

Contents:

Entities: User, Admin, Instructor, Student, Branch, Track, Course, Exam, Question, Answer, CoursePolicy, StudentExam, StudentAnswer, Applicant, Log, Translation.

Enums: Gender, ExamStatus, ExamType, QuestionType, ApplicantStatus, UserRole.

Interfaces: IRepository<T>, IUnitOfWork, IExamService, IStudentService, ICourseService...

Dependencies: None.

🟠 Common Layer

Purpose: Shared utilities and constants.

Contents:

Constants (like default pass percentages, max attempts, roles).

Helpers (e.g., PasswordHasher, RandomCodeGenerator).

Logging (Serilog configuration and wrappers).

Dependencies: None special (shared across all).

🟡 Data Layer

Purpose: Persistence and EF Core configurations.

Contents:

LegacyDbContext (now reflects the new normalized DB).

Configurations: all Fluent API mappings (BranchTrackConfig, CoursePolicyConfig, etc.).

Repositories: implement domain interfaces.

Migrations: created and maintained by EF.

Schema Highlights (synchronized with DB):

TPH inheritance for User subclasses (Admin, Instructor, Student).

Full relational design with BranchTracks, TrackCourses, InstructorCourse, CoursePolicies.

FK constraints with cascade behavior defined.

Translation table for multilingual fields.

Dependencies: Core + Common.

🟢 Application Layer

Purpose: Business logic orchestration.

Contents:

Services:

UserService (Authentication, CRUD)

StudentService (Enrollments, Exam registration)

InstructorService (Exam creation, grading)

AdminService (System configuration)

ExamService (Exam generation, evaluation)

Dependency Injection registration (DbContext, Repositories, Logging, Services).

Configures EF options (lazy loading, query tracking).

Dependencies: Core + Data + Common.

🔵 UI Layer (WinForms)

Purpose: Presentation layer for end-users (multi-role interface).

Structure:

Forms separated by Role:

Admin: Manage branches, tracks, users, course policies.

Instructor: Manage exams, questions, results.

Student: View courses, take exams, view grades.

Shared: Login, Dashboard, Profile.

Rules:

UI talks only to the Application layer, never directly to Data.

Uses dependency injection for service access.

Dependencies: Application + Core + Common.

🧪 Tests Layer

Purpose: Automated testing for reliability.

Contents:

Unit Tests for Services (using Moq for repositories).

Integration Tests using EF InMemory DB to test full data operations.

FluentAssertions for readable validation.

Dependencies: Core + Application + Data + Common.

📦 Packages per Layer

Core: System.ComponentModel.Annotations

Common: Serilog, Serilog.Sinks.File, Serilog.Sinks.Console

Data: Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools, Microsoft.Extensions.Logging.Console

Application: Microsoft.Extensions.DependencyInjection.Abstractions, Microsoft.EntityFrameworkCore.Proxies, (optional) FluentValidation

UI: Microsoft.Extensions.DependencyInjection, Microsoft.Extensions.Configuration, Microsoft.Extensions.Configuration.Json

Tests: xUnit, Moq, Microsoft.EntityFrameworkCore.InMemory, FluentAssertions

🗄 Updated Database Model (2025)
🔹 Branches

Each branch has one Manager (Instructor).

Linked with multiple Tracks via BranchTracks.

🔹 Tracks

Exist globally but can be available in multiple branches.

Each branch-track pair has a Supervisor (Instructor).

🔹 Courses

Two courses per track (seeded).

Linked to tracks via TrackCourses.

🔹 Instructors

Belong to one branch.

Can teach multiple courses through InstructorCourse.

Some act as Branch Managers or Track Supervisors.

🔹 Students

Belong to a single Branch and a Track (valid pair via BranchTracks).

Take exams based on their assigned TrackCourses.

🔹 CoursePolicies

Define pass percentages and validity durations per TrackCourse.

Managed by an instructor or admin (ManagedBy).

🔹 Exams

Linked to a TrackCourse.

Created by an instructor (CreatedBy).

Have types (Final, Practice) and statuses (Queued, Started, Finished, Cancelled).

🔹 Questions & Answers

Linked to courses.

Support types: True/False, ChooseOne, ChooseAll.

Answers table supports multiple correct answers.

🔹 StudentExam & StudentAnswer

Represent actual exam sessions and student responses.

Used for auto-grading and score calculation.

🔹 Applicants

Manage student intake workflow (Pending, UnderReview, Accepted, Rejected).

🔹 Logs

Capture user actions and exceptions (linked to UserID).

🔹 Translations

Provide multilingual support for entities like Courses, Tracks, etc.

🧩 Patterns in Use

Onion Architecture (Clean)

Repository Pattern

Unit of Work

Dependency Injection

TPH (Table-per-Hierarchy) for Users

Configuration by Convention + Fluent API