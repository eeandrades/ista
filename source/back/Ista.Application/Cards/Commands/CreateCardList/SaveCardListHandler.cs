using Aeon;
using Aeon.Domain;
using FluentValidation.Results;
using Ista.Domain.Cards;
using Ista.Domain.Users;
using System;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Commands.SaveCardList
{
    internal class SaveCardListHandler : Aeon.Domain.CommandHandler<SaveCardListRequest, SaveCardListResponse>
    {
        private readonly ICardListRepository _cardListRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public SaveCardListHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, ICardListRepository cardListRepository)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this._userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this._cardListRepository = cardListRepository ?? throw new ArgumentNullException(nameof(cardListRepository));
        }

        async protected override Task<SaveCardListResponse> DoExecute(SaveCardListRequest command)
        {
            var user = this._userRepository.FindById(command.OwnerUserId);
            if (user.IsEmpty)
                return new ValidationResult()
                    .AddError($"Usuário {command.OwnerUserId} não encontrado.")
                    .CreateResponse<SaveCardListResponse>();

            CardList cardList = new()
            {
                Id = command.Id.IsEmpty() ? Guid.NewGuid() : command.Id,
                CreationDate = DateTime.Now,
                Owner = user,
                User = user,
            };

            cardList.Name = command.Name;
            cardList.Scope = (Scope)command.Scope;

            await this._cardListRepository.Save(cardList);

            try
            {
                await this._unitOfWork.Commit();
            }
            catch
            {
                await this._unitOfWork.Rollback();
                throw;
            }

            return new SaveCardListResponse()
            {
                CadListUid = cardList.Id,
            };
        }
    }
}
