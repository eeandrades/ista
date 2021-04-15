using FluentValidation;
using FluentValidation.Results;
using Ista.Domain.Cards;
using System.Threading;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Queries.GetCardListById
{
    public class GetCardListByIdRequestValidator : FluentValidation.AbstractValidator<GetCardListByIdRequest>
    {
        private readonly CardListValidator _cardListValidator;

        public GetCardListByIdRequestValidator(CardListValidator cardListValidator)
        {
            this._cardListValidator = cardListValidator ?? throw new System.ArgumentNullException(nameof(cardListValidator));
            RuleFor(c => c.ListId)
                .NotEmpty()
                .WithErrorCode("0001")
                .WithMessage("Informe o id da lista");

        }

        async public override Task<ValidationResult> ValidateAsync(ValidationContext<GetCardListByIdRequest> context, CancellationToken cancellation = default)
        {
            var result = await base.ValidateAsync(context, cancellation);

            if (result.IsValid)
            {
                var request = context.InstanceToValidate;
                await this._cardListValidator.ListExistsForUser(request.OwnerId, request.ListId, result);
            }

            return result;
        }
    }
}
