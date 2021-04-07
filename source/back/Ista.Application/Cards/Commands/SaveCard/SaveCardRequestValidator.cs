using Aeon.Domain;
using FluentValidation;
using System.Linq;

namespace Ista.Application.Cards.Commands.SaveCard
{
    public class SaveCardRequestValidator :  FluentValidation.AbstractValidator<SaveCardRequest>
    {
        public SaveCardRequestValidator()
        {
            RuleFor(c => c.ListId)
                .NotEmpty()
                .WithErrorCode("0003")
                .WithMessage("Informe a lista");

            RuleFor(c => c.FrontText)
                .NotEmpty()
                .WithErrorCode("0004")
                .WithMessage("Informe o texto da frente");

            RuleFor(c => c.BackText)
                .NotEmpty()
                .WithErrorCode("0005")
                .WithMessage("Informe o texto de trás");
        }
    }
}
