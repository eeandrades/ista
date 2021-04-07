using Aeon.Domain;
using FluentValidation.Results;
using Ista.Domain.Cards;

namespace Ista.Application.Cards.Queries.GetCardListById
{
    internal class GetCardListByIdHandler : Aeon.Domain.CommandHandler<GetCardListByIdRequest, GetCardListByIdResponse>
    {
        private readonly ICardListRepository cardListRepository;

        public GetCardListByIdHandler(ICardListRepository cardListRepository)
        {
            this.cardListRepository = cardListRepository;
        }

        protected override GetCardListByIdResponse DoExecute(GetCardListByIdRequest command)
        {
            var cardList = this.cardListRepository.FindById(command.ListId);

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
