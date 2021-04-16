using FluentValidation;
using FluentValidation.Results;
using Ista.Domain.Cards;
using Ista.Domain.Users;
using System.Threading;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Queries.GetCardListByUser
{
    public class GetCardListByUserRequestValidator : FluentValidation.AbstractValidator<GetCardListByUserRequest>
    {
        private readonly UserValidator _userValidator;

        public GetCardListByUserRequestValidator(UserValidator userValidator)
        {
            this._userValidator = userValidator ?? throw new System.ArgumentNullException(nameof(userValidator));

            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithErrorCode("0001")
                .WithMessage("Informe o id do usuário");
        }

        async public override Task<ValidationResult> ValidateAsync(ValidationContext<GetCardListByUserRequest> context, CancellationToken cancellation = default)
        {
            var result = await base.ValidateAsync(context, cancellation);

            var request = context.InstanceToValidate;

            if (result.IsValid)
            {
                await this._userValidator.UserExists(request.UserId, result);
            }

            return result;
        }
    }
}
