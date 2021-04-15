using FluentValidation;
using FluentValidation.Results;
using Ista.Domain.Cards;
using Ista.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Commands.CardsList
{
    public class CardListRequestValidateBase<TRequest, TResponse>: FluentValidation.AbstractValidator<TRequest>
        where TRequest: CardListRequestBase<TResponse>
        where TResponse: Aeon.Domain.ResponseBase
    {
        private readonly UserValidator _userValidator;

        public CardListRequestValidateBase(UserValidator userValidator)
        {
            this._userValidator = userValidator ?? throw new System.ArgumentNullException(nameof(userValidator));


            RuleFor(c => c.Name)
                .NotEmpty()
                .WithErrorCode("0001")
                .WithMessage("Informe o nome da lista");

            RuleFor(c => c.OwnerUserId)
                .NotEmpty()
                .WithErrorCode("0002")
                .WithMessage("Informe o dono da lista");
        }

        async public override Task<ValidationResult> ValidateAsync(ValidationContext<TRequest> context, CancellationToken cancellation = default)
        {
            var result = await base.ValidateAsync(context, cancellation);
            var request = context.InstanceToValidate;
            if (result.IsValid)
            {
                await this._userValidator.UserExists(request.OwnerUserId, result);
            }
            return result;
        }
    }
}
