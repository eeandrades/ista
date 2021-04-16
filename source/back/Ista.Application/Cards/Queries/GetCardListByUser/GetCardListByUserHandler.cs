using Ista.Domain.Cards;
using System.Linq;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Queries.GetCardListByUser
{
    internal class GetCardListByUserHandler : Aeon.Domain.Handler<GetCardListByUserRequest, GetCardListByUserResponse>
    {
        private readonly ICardListQuery _cardListQuery;

        public GetCardListByUserHandler(ICardListQuery cardListQuery)
        {
            this._cardListQuery = cardListQuery;
        }

        async protected override Task<GetCardListByUserResponse> DoExecuteAsync(GetCardListByUserRequest command)
        {
            var cards = (await this._cardListQuery.FindByUser(command.UserId))
                .Select(c => new CardListBrief()
                {
                    Id = c.Id,
                    Name = c.Name,
                    CardCount = c.CardCount,
                    CreationDate = c.CreationDate
                });

            return new GetCardListByUserResponse()
            {
                Cards = cards
            };
        }
    }
}
