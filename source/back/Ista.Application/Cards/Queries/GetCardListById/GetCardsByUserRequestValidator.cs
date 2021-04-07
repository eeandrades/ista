using FluentValidation;

namespace Ista.Application.Cards.Queries.GetCardListById
{
    public class GetCardListByIdRequestValidator : FluentValidation.AbstractValidator<GetCardListByIdRequest>
    {
        public GetCardListByIdRequestValidator()
        {
            RuleFor(c => c.ListId)
                .NotEmpty()
                .WithErrorCode("0001")
                .WithMessage("Informe o id da lista");
        }
    }
}
