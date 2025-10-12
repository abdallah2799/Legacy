# Legacy Examination System

## Project Overview

The Legacy Examination System is a comprehensive examination management system designed for educational institutions with multiple branches and tracks, following the ITI (Information Technology Institute) model. The system handles the administration of students, instructors, and administrators, with specialized roles for Branch Managers and Track Supervisors.

### Key Features

- Multi-branch and multi-track management
- Comprehensive exam creation and management
- Automated grading and result processing
- Course policy management
- Multilingual support
- Detailed reporting system
- Applicant management workflow

## Architecture

The project follows the Clean Architecture (Onion Architecture) pattern, organized into the following layers:

### 🟣 Core Layer (Domain)

The heart of the application, containing:

- Domain Entities:
  - User (Admin, Instructor, Student)
  - Branch, Track, Course
  - Exam, Question, Answer
  - StudentExam, StudentAnswer
  - Applicant, Log, Translation

- Enums:
  - GenderEnum
  - ExamStatusEnum
  - ExamTypeEnum
  - QuestionType
  - ApplicationStatus
  - UserRoleEnum

- Interfaces for repositories and services

Dependencies: None (Independent layer)

### 🟠 Common Layer

Shared utilities and constants used across the application:

- Constants
  - Validation rules
  - Default values
  - System configurations
  - Cache durations

- Helpers
  - PasswordHelper (Secure password hashing)
  - Validator (Input validation)
  - EmailSettings
  - EncryptionHelper
  - MigrationConstraintsHelper
  - ReportExporter

Dependencies: None (Shared utilities)

### 🟡 Data Layer

Handles data persistence and database interactions:

- LegacyDbContext
- Entity Configurations
- Repository Implementations
- Migration Management
- Stored Procedures

Key Features:
- TPH inheritance for User hierarchy
- Complex relationships (BranchTracks, TrackCourses)
- Optimized query performance
- Data integrity constraints

Dependencies: Core, Common

### 🟢 Application Layer

Business logic orchestration:

- Services:
  - AuthService (Authentication)
  - UserService (User management)
  - ExamService (Exam operations)
  - CourseService (Course management)
  - ReportService (Report generation)
  - ValidationService (Input validation)
  - CacheService (Data caching)
  - EmailService (Notifications)

Dependencies: Core, Data, Common

### 🔵 UI Layer

Presentation layer with role-based interfaces:

- Admin Interface
  - Branch/Track management
  - User administration
  - System configuration

- Instructor Interface
  - Exam creation
  - Question management
  - Result assessment

- Student Interface
  - Course access
  - Exam participation
  - Result viewing

## Developer Guide

### Services

#### Core Services

1. **AuthService**
   - User authentication
   - Role-based access control
   - Session management

2. **UserService**
   - User CRUD operations
   - Role management
   - Profile updates

3. **ExamService**
   - Exam creation and scheduling
   - Question randomization
   - Auto-grading
   - Result processing

4. **CourseService**
   - Course management
   - Policy enforcement
   - Track association

#### Support Services

1. **ValidationService**
   - Input validation
   - Business rule validation
   - Data integrity checks

2. **CacheService**
   - Data caching
   - Cache invalidation
   - Performance optimization

3. **ReportService**
   - PDF/Excel report generation
   - Performance analytics
   - Statistical analysis

4. **EmailService**
   - Notification delivery
   - Template management
   - Queue handling

### Helpers and Utilities

1. **PasswordHelper**
```csharp
// Password hashing with PBKDF2
PasswordHelper.HashPassword(string password)
PasswordHelper.VerifyPassword(string hashedPassword, string providedPassword)
```

2. **Validator**
```csharp
// Input validation
Validator.IsValidEmail(string email)
Validator.IsValidPhone(string phone)
Validator.IsValidAge(int age)
Validator.IsValidPassword(string password)
Validator.IsValidUsername(string username)
Validator.IsValidDateRange(DateTime start, DateTime end)
```

3. **Constants**
```csharp
// System defaults
Constants.Defaults.MIN_EXAM_DURATION_MINUTES = 30
Constants.Defaults.MAX_EXAM_DURATION_MINUTES = 180
Constants.Defaults.DEFAULT_PASS_PERCENTAGE = 60
Constants.Defaults.MAX_EXAM_ATTEMPTS = 3
```

### Working with the System

1. **Exam Creation**
```csharp
await examService.CreateExamAsync(new Exam {
    Title = "Final Exam",
    DurationMinutes = 120,
    TrackCourseId = trackCourseId,
    ScheduledAt = DateTime.Now.AddDays(7)
});
```

2. **User Management**
```csharp
await userService.RegisterAsync(new User {
    FullName = "John Doe",
    Email = "john@example.com",
    Username = "johndoe"
}, "password123");
```

3. **Report Generation**
```csharp
var reportBytes = await reportService.GenerateExamReport(examId, ReportTypeEnum.PDF);
```

4. **Validation Usage**
```csharp
if (!Validator.IsValidEmail(email))
    throw new ValidationException("Invalid email format");
```

### Database Operations

1. **Using Repositories**
```csharp
// Example: Fetching student exams
var studentExams = await studentExamRepository.GetByStudentAsync(studentId);
```

2. **Transaction Management**
```csharp
using var transaction = await _context.Database.BeginTransactionAsync();
try {
    // Perform operations
    await transaction.CommitAsync();
} catch {
    await transaction.RollbackAsync();
    throw;
}
```

### Caching Strategy

1. **Cache Duration Constants**
```csharp
CACHE_COURSES_EXPIRATION = TimeSpan.FromHours(2)
CACHE_TRACKS_EXPIRATION = TimeSpan.FromHours(2)
CACHE_USERS_EXPIRATION = TimeSpan.FromMinutes(30)
```

2. **Cache Usage**
```csharp
var courses = await _cacheService.GetOrSetAsync(
    "courses",
    () => _courseRepository.GetAllAsync(),
    Constants.Defaults.CACHE_COURSES_EXPIRATION
);
```

For more detailed information about specific components or implementation details, please refer to the individual service and component documentation in the codebase.

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