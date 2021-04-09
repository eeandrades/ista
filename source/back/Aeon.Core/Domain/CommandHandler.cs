using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Aeon.Domain
{
    public abstract class CommandHandler<TCommand, TCommandResponse> : IRequestHandler<TCommand, TCommandResponse>
       where TCommand : IValidable, IRequest<TCommandResponse>
        where TCommandResponse : ResponseBase, new()
    {
        private ValidationResult Validate(TCommand command)
        {
            return command.Validate(out var commandValidate) ? this.DoValidate(command) : commandValidate;
        }

        private bool Validate(TCommand command, out ValidationResult validationResult)
        {
            validationResult = this.Validate(command);
            return validationResult.IsValid;
        }

        protected virtual ValidationResult DoValidate(TCommand command) => new ValidationResult();

        protected abstract Task<TCommandResponse> DoExecute(TCommand command);

        Task<TCommandResponse> IRequestHandler<TCommand, TCommandResponse>.Handle(TCommand request, CancellationToken cancellationToken)
        {
            if (this.Validate(request, out var validationResult))
            {
                return  this.DoExecute(request);
            }
            else
            {
                return validationResult.CreateResponseAsync<TCommandResponse>();
            }
        }
    }
}
