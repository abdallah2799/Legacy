using Core.Models;
using FluentValidation;
using Common;

namespace Application.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required")
                .MaximumLength(Constants.Validation.MAX_FULLNAME_LENGTH)
                .WithMessage($"Full name cannot exceed {Constants.Validation.MAX_FULLNAME_LENGTH} characters");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters")
                .MaximumLength(50).WithMessage("Username cannot exceed 50 characters")
                .Matches(@"^[a-zA-Z0-9_]+$").WithMessage("Username can only contain letters, numbers, and underscores");

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
                .WithMessage($"Address cannot exceed {Constants.Validation.MAX_ADDRESS_LENGTH} characters");

            RuleFor(x => x.RoleEnum)
                .NotEmpty().WithMessage("Role is required")
                .IsInEnum().WithMessage("Invalid role");
        }
    }
}
