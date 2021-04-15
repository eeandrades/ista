using Aeon;
using Aeon.Domain;
using FluentValidation.Results;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Commands.CardsList.Update
{
    public class UpdateCardListRequest : CardListRequestBase<UpdateCardListResponse>
    {
        [JsonIgnore]
        public Guid CardListId { get; set; }
    }
}
