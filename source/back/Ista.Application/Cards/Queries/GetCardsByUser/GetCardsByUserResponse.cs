using System.Collections.Generic;

namespace Ista.Application.Cards.Queries.GetCardsByUser
{
    public class GetCardsByUserResponse : Aeon.Domain.ResponseBase
    {
        public IEnumerable<CardListBrief> Cards { get; init; }
    }
}
