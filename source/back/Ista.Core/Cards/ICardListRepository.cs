using System;
using System.Threading.Tasks;

namespace Ista.Domain.Cards
{
    public interface ICardListRepository
    {
        Task Save(CardList cardList);

        Task<CardList> FindById(Guid cardListId);
    }
}
