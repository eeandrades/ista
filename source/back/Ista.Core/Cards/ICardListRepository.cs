using System;
using System.Threading.Tasks;

namespace Ista.Domain.Cards
{
    public interface ICardListRepository
    {
        Task Create(CreateCardListArgs cardListArgs);

        Task Update(CreateCardListArgs cardListArgs);


        Task CreateCard(CreateCardArgs createCardArgs);

        Task UpdateCard(UpdateCardArgs updateCardArgs);
    }
}
