using Aeon;
using Aeon.Domain;
using FluentValidation.Results;
using System;

namespace Ista.Application.Cards.Commands.SaveCardList
{
    public class SaveCardListRequest : Aeon.Domain.RequestBase<SaveCardListResponse>
    {
        public Guid Id { get; init; }
        public Guid OwnerUserId { get; set; }
        public string Name { get; set; }
        public CardListScope Scope { get; set; }
        protected override ValidationResult DoValidate() => new SaveCardListRequestValidator().Validate(this);

        public bool IsNew => this.Id.IsEmpty();
    }
}
