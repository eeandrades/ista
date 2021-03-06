using FluentValidation.Results;
using System.Threading.Tasks;

namespace Aeon.Domain
{
    public static class ValidationResultExtension
    {
        public static TCommandResponse CreateResponse<TCommandResponse>(this ValidationResult validationResult)
            where TCommandResponse : ResponseBase, new()
        {
            return new TCommandResponse()
            {
                ValidationResult = validationResult
            };
        }

        public static Task<TCommandResponse> CreateResponseAsync<TCommandResponse>(this ValidationResult validationResult)
            where TCommandResponse : ResponseBase, new()
        {
            return Task.FromResult(new TCommandResponse()
            {
                ValidationResult = validationResult
            });
        }

        public static ValidationResult AddError(this ValidationResult validationResult, string propertyName, string errorMessage)
        {
            validationResult.Errors.Add(new ValidationFailure(propertyName, errorMessage));
            return validationResult;
        }

        public static ValidationResult AddError(this ValidationResult validationResult, string errorMessage)
        {
            return validationResult.AddError(string.Empty, errorMessage);
        }

        public static void Merge(this ValidationResult source, ValidationResult dest)
        {
            foreach (var err in dest.Errors)
            {
                source.Errors.Add(err);
            }
        }
    }
}
