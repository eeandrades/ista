using FluentValidation.Results;
using System;
using System.Text.Json.Serialization;

namespace Ista.Application.Cards.Queries.GetCardListByUser
{
    public class GetCardListByUserRequest : Aeon.Domain.RequestBase<GetCardListByUserResponse>
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

    }
}
