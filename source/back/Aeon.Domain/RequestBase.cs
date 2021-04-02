using FluentValidation.Results;
using MediatR;

namespace Aeon.Domain
{
    public abstract class RequestBase<TCommandResponse> : IRequest<TCommandResponse>, IValidable
        where TCommandResponse : ResponseBase
    {
        public ValidationResult Validate()
        {
            return this.DoValidate();
        }

        public bool Validate(out ValidationResult validationResult)
        {
            validationResult = this.DoValidate();
            return validationResult.IsValid;
        }
        protected virtual ValidationResult DoValidate() => new ValidationResult();
    }


    public abstract class RequestBase : RequestBase<ResponseBase>
    {
    }
}
