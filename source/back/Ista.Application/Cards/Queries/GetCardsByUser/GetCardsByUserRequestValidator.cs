using FluentValidation;

namespace Ista.Application.Cards.Queries.GetCardsByUser
{
    public class GetCardsByUserRequestValidator : FluentValidation.AbstractValidator<GetCardsByUserRequest>
    {
        public GetCardsByUserRequestValidator()
        {
            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithErrorCode("0001")
                .WithMessage("Informe o id do usuário");
        }
    }
}
