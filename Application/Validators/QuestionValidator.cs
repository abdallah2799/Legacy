using Core.Models;
using FluentValidation;
using Common;

namespace Application.Validators
{
    public class QuestionValidator : AbstractValidator<Question>
    {
        public QuestionValidator()
        {
            RuleFor(x => x.Body)
                .NotEmpty().WithMessage("Question body is required")
                .MaximumLength(Constants.Validation.MAX_QUESTION_BODY_LENGTH)
                .WithMessage($"Question body cannot exceed {Constants.Validation.MAX_QUESTION_BODY_LENGTH} characters");

            RuleFor(x => x.Marks)
                .GreaterThan(0).WithMessage("Marks must be greater than 0")
                .InclusiveBetween(Constants.Defaults.MIN_QUESTION_MARKS, Constants.Defaults.MAX_QUESTION_MARKS)
                .WithMessage($"Marks must be between {Constants.Defaults.MIN_QUESTION_MARKS} and {Constants.Defaults.MAX_QUESTION_MARKS}");

            RuleFor(x => x.CourseId)
                .GreaterThan(0).WithMessage("Course ID is required");

            RuleFor(x => x.CreatedBy)
                .GreaterThan(0).WithMessage("Created by user ID is required");

            RuleFor(x => x.QuestionTypeEnum)
                .NotEmpty().WithMessage("Question type is required")
                .IsInEnum().WithMessage("Invalid question type");
        }
    }
}
