using Aeon.Domain;
using FluentValidation;
using System.Linq;

namespace Ista.Commands.Cards.CreateCardList
{
    public class CreateCardListRequestValidator :  FluentValidation.AbstractValidator<CreateCardListRequest>
    {
        public CreateCardListRequestValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithErrorCode("0001")
                .WithMessage("Informe o nome da lista");

            RuleFor(c => c.OwnerUserId)
                .NotEmpty()
                .WithErrorCode("0002")
                .WithMessage("Informe o dono da lista");
        }
    }
}
