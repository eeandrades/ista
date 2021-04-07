using Aeon.Domain;
using FluentValidation;
using System.Linq;

namespace Ista.Application.Cards.Commands.SaveCardList
{
    public class SaveCardListRequestValidator :  FluentValidation.AbstractValidator<SaveCardListRequest>
    {
        public SaveCardListRequestValidator()
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
