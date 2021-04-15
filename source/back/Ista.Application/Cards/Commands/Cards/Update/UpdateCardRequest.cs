using Aeon;
using Aeon.Domain;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Commands.Cards.Update
{
    public class UpdateCardRequest : CardRequestBase<UpdateCardResponse>
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid CardId { get; set; }
    }
}
