using Ista.Domain.Cards;
using System;
using System.Linq;

namespace Ista.Repository.FileSystem.Cards
{
    public class CardListRepository : Ista.Domain.Cards.ICardListRepository
    {
        private string GetFileName(string userId, string listId)
        {
            return $"{typeof(CardList).Name}-{userId}-{listId}";
        }
        CardList ICardListRepository.FindById(Guid cardId)
        {
            var pattern = GetFileName("*", Convert.ToString(cardId));
            var fileName = FileHelper.GetFiles(pattern).FirstOrDefault();

            return fileName != null ? FileHelper.GetData<CardList>(fileName, CardList.Empty) : CardList.Empty;
        }

        void ICardListRepository.Save(CardList cardList)
        {
            string fileName = GetFileName(Convert.ToString(cardList.Owner.Id), Convert.ToString(cardList.Id));
            FileHelper.Create(fileName, cardList);
        }
    }
}
 