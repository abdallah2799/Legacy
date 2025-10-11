using FluentValidation;
using Microsoft.Extensions.Logging;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ValidationService> _logger;

        public ValidationService(IServiceProvider serviceProvider, ILogger<ValidationService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task<ValidationResult> ValidateAsync<T>(T model)
        {
            try
            {
                var validatorType = typeof(IValidator<>).MakeGenericType(typeof(T));
                var validator = _serviceProvider.GetService(validatorType) as IValidator<T>;
                if (validator == null)
                {
                    _logger.LogWarning("No validator found for type: {Type}", typeof(T).Name);
                    return new ValidationResult { IsValid = true };
                }

                var result = await validator.ValidateAsync(model);
                return new ValidationResult
                {
                    IsValid = result.IsValid,
                    Errors = result.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating model of type: {Type}", typeof(T).Name);
                return new ValidationResult
                {
                    IsValid = false,
                    Errors = new List<string> { "Validation error occurred" }
                };
            }
        }

        public async Task ValidateAndThrowAsync<T>(T model)
        {
            var result = await ValidateAsync(model);
            if (!result.IsValid)
            {
                throw new ValidationException(string.Join("; ", result.Errors));
            }
        }
    }

    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
        public ValidationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
