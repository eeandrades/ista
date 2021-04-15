using Aeon.Domain;
using FluentValidation;
using FluentValidation.Results;
using Ista.Domain.Cards;
using Ista.Domain.Users;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Commands.Cards
{
    public class CardRequestValidatorBase<TRequest, TResponse>: AbstractValidator<TRequest>
        where TRequest: CardRequestBase<TResponse>
        where TResponse: Aeon.Domain.ResponseBase
    {
        private readonly UserValidator _userValidator;
        private readonly CardListValidator _cardListValidator;

        public CardRequestValidatorBase(UserValidator userValidator, CardListValidator cardListValidator)
        {
            this._userValidator = userValidator ?? throw new ArgumentNullException(nameof(userValidator));
            this._cardListValidator = cardListValidator ?? throw new ArgumentNullException(nameof(cardListValidator));

            RuleFor(c => c.FrontText)
                .NotEmpty()
                .WithErrorCode("0004")
                .WithMessage("Informe o texto da frente");

            RuleFor(c => c.BackText)
                .NotEmpty()
                .WithErrorCode("0005")
                .WithMessage("Informe o texto de trás");
        }

        async public override Task<ValidationResult> ValidateAsync(ValidationContext<TRequest> context, CancellationToken cancellation = default)
        {
            var result = await base.ValidateAsync(context, cancellation);
            var request = context.InstanceToValidate;
            if (result.IsValid)
            {
                await this._userValidator.UserExists(request.OwnerUserId, result);
                if (result.IsValid)
                await this._cardListValidator.ListExistsForUser(request.OwnerUserId, request.CardListId, result);
            }
            return result;
        }
    }
}
