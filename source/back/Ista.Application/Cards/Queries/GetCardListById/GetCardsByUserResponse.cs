using System.Collections.Generic;

namespace Ista.Application.Cards.Queries.GetCardListById
{
    public class GetCardListByIdResponse : Aeon.Domain.ResponseBase
    {
        public CardList CardList { get; init; }
    }
}
