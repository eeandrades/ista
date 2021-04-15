using FluentValidation.Results;
using System;
using System.Text.Json.Serialization;

namespace Ista.Application.Cards.Queries.GetCardListById
{
    public class GetCardListByIdRequest : Aeon.Domain.RequestBase<GetCardListByIdResponse>
    {
        public Guid ListId { get; set; }

        [JsonIgnore]
        public Guid OwnerId { get; set; }

    }
}
