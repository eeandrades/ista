using Aeon.Domain;
using FluentValidation.Results;
using Ista.Domain.Cards;
using Ista.Domain.Users;
using System;

namespace Ista.Application.Cards.Commands.SaveCardList
{
    internal class SaveCardListHandler : Aeon.Domain.CommandHandler<SaveCardListRequest, SaveCardListResponse>
    {
        private readonly ICardListRepository _cardListRepository;
        private readonly IUserRepository _userRepository;

        public SaveCardListHandler(IUserRepository userRepository, ICardListRepository cardListRepository)
        {
            this._userRepository = userRepository;
            this._cardListRepository = cardListRepository;
        }

        protected override SaveCardListResponse DoExecute(SaveCardListRequest command)
        {
            var user = this._userRepository.FindById(command.OwnerUserId);
            if (user.IsEmpty)
                return new ValidationResult()
                    .AddError($"Usuário {command.OwnerUserId} não encontrado.")
                    .CreateResponse<SaveCardListResponse>();


            var cardList = this._cardListRepository.FindById(command.Id);

            if (cardList.IsEmpty)
                cardList = new CardList()
                {
                    Id = command.Id.IsEmpty() ? Guid.NewGuid() : command.Id,
                    CreationDate = DateTime.Now,
                    Owner = user,
                    User = user,
                };

            cardList.Name = command.Name;
            cardList.Scope = (Scope)command.Scope;

            this._cardListRepository.Save(cardList);

            return new SaveCardListResponse()
            {
                CadListUid = cardList.Id,
            };
        }
    }
}
