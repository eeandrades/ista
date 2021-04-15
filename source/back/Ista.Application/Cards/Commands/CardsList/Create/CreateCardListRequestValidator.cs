using Aeon.Domain;
using FluentValidation;
using FluentValidation.Results;
using Ista.Domain.Cards;
using Ista.Domain.Users;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Commands.CardsList.Create
{
    public class CreateCardListRequestValidator : CardListRequestValidateBase<CreateCardListRequest, CreateCardListResponse>
    {
        private readonly CardListValidator _cardListValidator;

        public CreateCardListRequestValidator(UserValidator userValidator, CardListValidator cardListValidator)
            : base(userValidator)
        {
            this._cardListValidator = cardListValidator ?? throw new System.ArgumentNullException(nameof(cardListValidator));
        }

        async public override Task<ValidationResult> ValidateAsync(ValidationContext<CreateCardListRequest> context, CancellationToken cancellation = default)
        {
            var result = await base.ValidateAsync(context, cancellation);

            var request = context.InstanceToValidate;

            if (result.IsValid)
            {
                await this._cardListValidator.NomeJaExiste(new() { OwnerUserId = request.OwnerUserId, Name = request.Name }, result);

            }
            return result;
        }


    }
}
