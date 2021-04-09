using Ista.Domain.Cards;
using Ista.Repository.EntityFramework.Cards.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ista.Repository.EntityFramework.Cards
{
    internal class CardListRepository : ICardListRepository, ICardListQuery
    {
        private readonly AppContext _appContext;

        public CardListRepository(AppContext appDbContext)
        {
            this._appContext = appDbContext;
        }
        async Task<Domain.Cards.CardList> ICardListRepository.FindById(Guid cardListId)
        {
            var strId = Convert.ToString(cardListId);

            var cardListTable = this._appContext.CardList
                .Include(c => c.Owner)
                .Include(c => c.Cards)
                .Where(c => c.Uid == strId)
                .FirstOrDefault() ?? new CardListTable();


            return await Task.FromResult(cardListTable.ToEntity());
        }

        async Task<IEnumerable<CardListBrief>> ICardListQuery.FindByUser(Guid userId)
        {
            var strUserId = userId.ToString();

            var result = this._appContext.Set<Tables.CardListTable>()
                .Where(c => c.UserOwnerId == strUserId)
                .Select(c => new CardListBrief()
                {
                    Id = new Guid(c.Uid),
                    Name = c.Name,
                    CreationDate = DateTime.Now,
                    CardCount = c.Cards.Count
                });

            return await Task.FromResult(result);
        }

        async Task ICardListRepository.Save(Domain.Cards.CardList cardList)
        {
            var strId = cardList.Id.ToString();
            var cardListTable = this._appContext.CardList
                .Where(c => c.Uid == strId)
                .FirstOrDefault() ?? new CardListTable();

            var isNew = cardListTable.IsNew;

            cardListTable.FillFromEntity(cardList);

            if (isNew)
            {
                await this._appContext.AddAsync(cardListTable);
            }
        }
    }
}
