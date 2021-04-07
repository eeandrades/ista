using System;

namespace Ista.Domain.Cards
{
    public interface ICardListRepository
    {
        void Save(CardList cardList);

        CardList FindById(Guid cardId);
    }
}
