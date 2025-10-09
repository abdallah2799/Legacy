using FluentValidation;
using Common;
using System;

namespace Application.Validators
{
    public class ExamValidator : AbstractValidator<Exam>
    {
        public ExamValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Exam title is required")
                .MaximumLength(200).WithMessage("Exam title cannot exceed 200 characters");

            RuleFor(x => x.DurationMinutes)
                .GreaterThan(0).WithMessage("Duration must be greater than 0 minutes")
                .InclusiveBetween(Constants.Defaults.MIN_EXAM_DURATION_MINUTES, Constants.Defaults.MAX_EXAM_DURATION_MINUTES)
                .WithMessage($"Duration must be between {Constants.Defaults.MIN_EXAM_DURATION_MINUTES} and {Constants.Defaults.MAX_EXAM_DURATION_MINUTES} minutes");

            RuleFor(x => x.ScheduledAt)
                .GreaterThan(DateTime.UtcNow).WithMessage("Scheduled date must be in the future")
                .When(x => x.ScheduledAt.HasValue);

            RuleFor(x => x.FullMark)
                .GreaterThan(0).WithMessage("Full mark must be greater than 0")
                .When(x => x.FullMark.HasValue);

            RuleFor(x => x.PassMark)
                .GreaterThanOrEqualTo(0).WithMessage("Pass mark cannot be negative")
                .LessThanOrEqualTo(x => x.FullMark).WithMessage("Pass mark cannot exceed full mark")
                .When(x => x.PassMark.HasValue && x.FullMark.HasValue);

            RuleFor(x => x.TrackCourseId)
                .GreaterThan(0).WithMessage("Track course ID is required");

            RuleFor(x => x.CreatedBy)
                .GreaterThan(0).WithMessage("Created by user ID is required");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Exam type is required")
                .Must(type => Enum.TryParse<Common.Enums.ExamTypeEnum>(type, true, out _))
                .WithMessage("Invalid exam type");
        }
    }
}
