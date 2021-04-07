﻿using Ista.Domain.Cards;
using System.Linq;

namespace Ista.Application.Cards.Queries.GetCardsByUser
{
    internal class GetCardsByUserHandler : Aeon.Domain.CommandHandler<GetCardsByUserRequest, GetCardsByUserResponse>
    {
        private readonly ICardListQuery _cardListQuery;

        public GetCardsByUserHandler(ICardListQuery cardListQuery)
        {
            this._cardListQuery = cardListQuery;
        }

        protected override GetCardsByUserResponse DoExecute(GetCardsByUserRequest command)
        {
            var cards = this._cardListQuery.FindByUser(command.UserId)
                .Select(c => new CardListBrief()
                {
                    Id = c.Id,
                    Name = c.Name,
                    CardCount = c.CardCount,
                    CreationDate = c.CreationDate
                });

            return new GetCardsByUserResponse()
            {
                Cards = cards
            };
        }
    }
}
