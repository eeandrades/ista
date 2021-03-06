using FluentValidation.Results;

namespace Aeon.Domain
{
    public class ResponseBase<TContext> : ResponseBase
    {
        public TContext Context { get; set; }

        public ResponseBase()
        {

        }
        public ResponseBase(ValidationResult validationResult, TContext context) :
            base(validationResult)
        {
            this.Context = context;
        }

        public ResponseBase(TContext context) :
            base()
        {
            this.Context = context;
        }
    }
}
