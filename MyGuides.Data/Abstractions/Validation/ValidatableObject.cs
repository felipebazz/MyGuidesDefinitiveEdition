using FluentValidation.Results;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGuides.Domain.Abstractions.Validation
{
    public abstract class ValidatableObject : IValidatableObject
    {
        public virtual bool Valid => ValidationResult?.IsValid ?? Validate();

        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        protected void AddError(ValidationResult validationResult)
        {
            ValidationResult = ValidationResult ?? new ValidationResult();
            validationResult.Errors.ToList().ForEach(failure => ValidationResult.Errors.Add(failure));
        }

        protected void AddError(string errorMessage, ValidationResult validationResult = null)
        {
            ValidationResult = ValidationResult ?? new ValidationResult();
            ValidationResult.Errors.Add(new ValidationFailure(default, errorMessage));
            validationResult?.Errors.ToList().ForEach(failure => ValidationResult.Errors.Add(failure));
        }

        protected void AddError(string errorMessage, string propertyName)
        {
            ValidationResult = ValidationResult ?? new ValidationResult();
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, errorMessage));
        }

        public abstract bool Validate();
    }
}
