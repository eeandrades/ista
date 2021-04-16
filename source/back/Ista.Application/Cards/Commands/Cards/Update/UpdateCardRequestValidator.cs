using Aeon.Domain;
using FluentValidation;
using FluentValidation.Results;
using Ista.Domain.Cards;
using Ista.Domain.Users;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Commands.Cards.Update
{
    public class UpdateCardRequestValidator : CardRequestValidatorBase<UpdateCardRequest, UpdateCardResponse>
    {
        
        public UpdateCardRequestValidator(UserValidator userValidator, CardListValidator cardListValidator)
            :base(userValidator, cardListValidator)
        {
            RuleFor(c => c.CardListId)
                .NotEmpty()
                .WithErrorCode("0006")
                .WithMessage("O id da lista deve ser informado");

            RuleFor(c => c.CardId)
                .NotEmpty()
                .WithErrorCode("0008")
                .WithMessage("O id do cartão deve ser informado");

        }

    }
}
