using Ista.Domain.Cards;
using Ista.Repository.EntityFramework.Cards.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ista.Repository.EntityFramework.Cards
{
    internal class CardListQuerie : ICardListQuery
    {
        private readonly AppContext _appContext;

        public CardListQuerie(AppContext appDbContext)
        {
            this._appContext = appDbContext;
        }

        Task<bool> ICardListQuery.ExistsCardListName(ExistsCardListtNameArgs cardListExistsArgs)
        {
            var ownerUserId = Convert.ToString(cardListExistsArgs.OwnerUserId);
            var strId = Convert.ToString(cardListExistsArgs.CardListId);
            return _appContext.CardList
                .AnyAsync(c =>
                c.Name == cardListExistsArgs.Name &&
                c.UserOwnerId == ownerUserId &&
                c.Uid != strId);
        }

        private static bool NewMethod(string listName, string ownerUserId, CardListTable c)
        {
            return c.Name == listName && c.UserOwnerId == ownerUserId;
        }

        async Task<Domain.Cards.CardList> ICardListQuery.FindById(Guid cardListId)
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

        async Task<CardListInfo> ICardListQuery.FindInfo(Guid cardListId)
        {
            var table = await this._appContext.CardList
                .SingleOrDefaultAsync(c => c.Uid == cardListId.ToString());

            return table != null ?
                new CardListInfo()
                {
                    Id = cardListId,
                    OwnerId = Guid.Parse(table.UserOwnerId)
                }
                : CardListInfo.Empty;
        }
    }
}
