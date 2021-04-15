using FluentValidation.Results;
using System;
using System.Text.Json.Serialization;

namespace Ista.Application.Cards.Queries.GetCardsByUser
{
    public class GetCardsByUserRequest : Aeon.Domain.RequestBase<GetCardsByUserResponse>
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

    }
}
