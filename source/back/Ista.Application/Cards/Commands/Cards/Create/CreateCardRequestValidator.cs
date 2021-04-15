using Aeon.Domain;
using FluentValidation;
using FluentValidation.Results;
using Ista.Application.Cards.Commands.CardsList;
using Ista.Domain.Cards;
using Ista.Domain.Users;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Commands.Cards.Create
{
    public class CreateCardRequestValidator : CardRequestValidatorBase<CreateCardRequest, CreateCardResponse>
    {
        public CreateCardRequestValidator(UserValidator userValidator, CardListValidator cardListValidator) 
            : base(userValidator, cardListValidator)
        {
        }
    }
}
