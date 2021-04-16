using System.Collections.Generic;

namespace Ista.Application.Cards.Queries.GetCardListByUser
{
    public class GetCardListByUserResponse : Aeon.Domain.ResponseBase
    {
        public IEnumerable<CardListBrief> Cards { get; init; }
    }
}
