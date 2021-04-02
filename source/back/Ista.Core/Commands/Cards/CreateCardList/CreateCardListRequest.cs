using System;
using Aeon.Domain;
using FluentValidation.Results;

namespace Ista.Commands.Cards.CreateCardList
{
    public class CreateCardListRequest : Aeon.Domain.RequestBase<CreateCardListResponse>
    {
        protected override ValidationResult DoValidate() => new CreateCardListRequestValidator().Validate(this);
        public Guid OwnerUserId { get; set; }
        public string Name { get; set; }
        public CardListScope Scope { get; set; }
    }
}
