using System;
using Aeon.Domain;
using FluentValidation.Results;

namespace Ista.Application.Cards.Commands.SaveCard
{
    public class SaveCardRequest : Aeon.Domain.RequestBase<SaveCardResponse>
    {
        public Guid Id { get; init; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid ListId { get; set; }

        public string TipText { get; set; }

        public string FrontText { get; init; }

        public string BackText { get; init; }

        protected override ValidationResult DoValidate() => new SaveCardRequestValidator().Validate(this);
    }
}
