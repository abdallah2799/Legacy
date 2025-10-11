using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IValidationService
    {
        Task<ValidationResult> ValidateAsync<T>(T model);
        Task ValidateAndThrowAsync<T>(T model);
    }

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
