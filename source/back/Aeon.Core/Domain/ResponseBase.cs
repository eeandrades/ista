using FluentValidation.Results;
using System.Collections.Generic;

namespace Aeon.Domain
{
    public class ResponseBase
    {
        internal ValidationResult ValidationResult { get; init; }

        public ResponseBase()
        {
            this.ValidationResult = new ValidationResult();
        }

        public ResponseBase(ValidationResult validationResult)
        {
            this.ValidationResult = validationResult ?? throw new System.ArgumentNullException(nameof(validationResult));
        }

        public bool IsValid => this.ValidationResult?.IsValid ?? true;

        public bool IsInvalid => !this.IsValid;

        public IEnumerable<ValidationFailure> Messages => this.ValidationResult?.Errors ?? System.Array.Empty<ValidationFailure>();

        public void AddError(ValidationFailure validationFailure)
        {
            this.ValidationResult.Errors.Add(validationFailure);
        }
    }
}
