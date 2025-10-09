using Core.Models;
using FluentValidation;
using Common;

namespace Application.Validators
{
    public class ApplicantValidator : AbstractValidator<Applicant>
    {
        public ApplicantValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required")
                .MaximumLength(Constants.Validation.MAX_FULLNAME_LENGTH)
                .WithMessage($"Full name cannot exceed {Constants.Validation.MAX_FULLNAME_LENGTH} characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(Constants.Validation.MAX_EMAIL_LENGTH)
                .WithMessage($"Email cannot exceed {Constants.Validation.MAX_EMAIL_LENGTH} characters");

            RuleFor(x => x.Age)
                .InclusiveBetween(Constants.Validation.MIN_AGE, Constants.Validation.MAX_AGE)
                .WithMessage($"Age must be between {Constants.Validation.MIN_AGE} and {Constants.Validation.MAX_AGE}");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required")
                .MaximumLength(Constants.Validation.MAX_PHONE_LENGTH)
                .WithMessage($"Phone number cannot exceed {Constants.Validation.MAX_PHONE_LENGTH} characters")
                .Matches(@"^[\+]?[0-9\s\-\(\)]+$").WithMessage("Invalid phone number format");

            RuleFor(x => x.Address)
                .MaximumLength(Constants.Validation.MAX_ADDRESS_LENGTH)
                .WithMessage($"Address cannot exceed {Constants.Validation.MAX_ADDRESS_LENGTH} characters")
                .When(x => !string.IsNullOrEmpty(x.Address));

            RuleFor(x => x.ApplicationCode)
                .NotEmpty().WithMessage("Application code is required")
                .MaximumLength(20).WithMessage("Application code cannot exceed 20 characters");

            RuleFor(x => x.SelectedBranches)
                .NotEmpty().WithMessage("At least one branch must be selected")
                .Must(branches => branches != null && branches.Count > 0)
                .WithMessage("At least one branch must be selected");

            RuleFor(x => x.SelectedTracks)
                .NotEmpty().WithMessage("At least one track must be selected")
                .Must(tracks => tracks != null && tracks.Count > 0)
                .WithMessage("At least one track must be selected");

            RuleFor(x => x.ApplicationPasswordHash)
                .NotEmpty().WithMessage("Application password is required");
        }
    }
}
