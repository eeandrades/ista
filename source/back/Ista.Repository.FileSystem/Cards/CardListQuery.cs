using Ista.Domain.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ista.Repository.FileSystem.Cards
{
    public class CardListQuery : ICardListQuery
    {
        private string GetFileName(string userId, string listId)
        {
            return $"{typeof(CardList).Name}-{userId}-{listId}";
        }


        IEnumerable<CardListBrief> ICardListQuery.FindByUser(Guid userId)
        {
            var fileName = GetFileName(Convert.ToString(userId), "*");

            var files = FileHelper.GetFiles(fileName);

            return
                files
                    .Select(f => FileHelper.GetData<CardList>(f, CardList.Empty))
                    .Where(f => !f.IsEmpty)
                    .Select(c => new CardListBrief()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        CreationDate = c.CreationDate,
                        CardCount = c.Cards.Count()
                    });
        }
    }
}
