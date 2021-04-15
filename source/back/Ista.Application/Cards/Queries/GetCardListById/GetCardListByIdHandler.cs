using Aeon.Domain;
using FluentValidation.Results;
using Ista.Domain.Cards;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Queries.GetCardListById
{
    internal class GetCardListByIdHandler : Aeon.Domain.Handler<GetCardListByIdRequest, GetCardListByIdResponse>
    {
        private readonly GetCardListByIdRequestValidator _validator;
        private readonly ICardListQuery _cardListQuery;

        protected override Task<ValidationResult> DoValidateAsync(GetCardListByIdRequest command) => this._validator.ValidateAsync(command);

        public GetCardListByIdHandler(GetCardListByIdRequestValidator validator, ICardListQuery cardListQuery)
        {
            this._validator = validator ?? throw new System.ArgumentNullException(nameof(validator));
            this._cardListQuery = cardListQuery ?? throw new System.ArgumentNullException(nameof(cardListQuery));
        }

        async protected override Task<GetCardListByIdResponse> DoExecuteAsync(GetCardListByIdRequest command)
        {
            var cardList = await this._cardListQuery.FindById(command.ListId);

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
