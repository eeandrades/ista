using Ista.Domain.Cards;
using System.Linq;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Queries.GetCardsByUser
{
    internal class GetCardsByUserHandler : Aeon.Domain.Handler<GetCardsByUserRequest, GetCardsByUserResponse>
    {
        private readonly ICardListQuery _cardListQuery;

        public GetCardsByUserHandler(ICardListQuery cardListQuery)
        {
            this._cardListQuery = cardListQuery;
        }

        async protected override Task<GetCardsByUserResponse> DoExecuteAsync(GetCardsByUserRequest command)
        {
            var cards = (await this._cardListQuery.FindByUser(command.UserId))
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
