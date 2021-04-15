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
    internal class CardListRepository : ICardListRepository
    {
        private readonly AppContext _appContext;

        public CardListRepository(AppContext appDbContext)
        {
            this._appContext = appDbContext;
        }

        private static bool NewMethod(string listName, string ownerUserId, CardListTable c)
        {
            return c.Name == listName && c.UserOwnerId == ownerUserId;
        }

        async Task ICardListRepository.Create(CreateCardListArgs cardListArgs)
        {
            var cardListTable = CardListTable.CreateFromCardListCreateArgs(cardListArgs);

            await this._appContext.AddAsync(cardListTable);
        }

        async Task ICardListRepository.Update(CreateCardListArgs cardListArgs)
        {

            var strId = Convert.ToString(cardListArgs.Id);

            var cardListTable = await this._appContext.CardList.SingleOrDefaultAsync(c => c.Uid == strId);

            if (cardListTable == null)
            {
                throw new EntityNotFoundException(typeof(CardListTable), cardListArgs.Id);
            }
            cardListTable.Scope = (Int16)cardListArgs.Scope;
            cardListTable.Name = cardListArgs.Name;
        }

        async Task ICardListRepository.CreateCard(CreateCardArgs createCardArgs)
        {
            CardTable cardTable = new()
            {
                Uid = Convert.ToString(createCardArgs.CardId),
                IdCardList = Convert.ToString(createCardArgs.CardListId),
                TextBack = createCardArgs.BackText,
                TextFront = createCardArgs.FrontText,
                Tip = createCardArgs.Tip,
            };
            await this._appContext.AddAsync(cardTable);
        }

        async Task ICardListRepository.UpdateCard(UpdateCardArgs updateCardArgs)
        {

            var cardTable = await this._appContext.Card.SingleOrDefaultAsync(c => c.Uid == updateCardArgs.CardId.ToString());

            if (cardTable == null)
            {
                throw new EntityNotFoundException(typeof(CardTable), updateCardArgs.CardId);
            }
            cardTable.TextFront = updateCardArgs.FrontText;
            cardTable.TextBack = updateCardArgs.BackText;
            cardTable.Tip = updateCardArgs.Tip;
        }
    }
}
