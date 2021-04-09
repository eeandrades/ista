using Aeon.Domain;
using FluentValidation.Results;
using Ista.Domain.Cards;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Queries.GetCardListById
{
    internal class GetCardListByIdHandler : Aeon.Domain.CommandHandler<GetCardListByIdRequest, GetCardListByIdResponse>
    {
        private readonly ICardListRepository cardListRepository;

        public GetCardListByIdHandler(ICardListRepository cardListRepository)
        {
            this.cardListRepository = cardListRepository;
        }

        async protected override Task<GetCardListByIdResponse> DoExecute(GetCardListByIdRequest command)
        {
            var cardList = await this.cardListRepository.FindById(command.ListId);

            if (cardList.IsEmpty)
                return new ValidationResult()
                    .AddError($"Lista {command.ListId} não encontrada")
                    .CreateResponse<GetCardListByIdResponse>();

            return new GetCardListByIdResponse()
            {
                CardList = cardList.CreateFromEntity()
            };

        }
    }
}
