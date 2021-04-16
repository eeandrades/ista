using Aeon;
using Aeon.Domain;
using FluentValidation.Results;
using Ista.Domain.Cards;
using Ista.Domain.Users;
using System;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Commands.Cards.Create
{
    internal class CreateCardHandler : Aeon.Domain.Handler<CreateCardRequest, CreateCardResponse>
    {
        private readonly ICardListRepository _cardListRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly CreateCardRequestValidator _validator;

       protected override Task<ValidationResult> DoValidateAsync(CreateCardRequest command) => this._validator.ValidateAsync(command);

        public CreateCardHandler(IUnitOfWork unitOfWork, CreateCardRequestValidator validator, IUserRepository userRepository, ICardListRepository cardListRepository)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this._validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this._userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this._cardListRepository = cardListRepository ?? throw new ArgumentNullException(nameof(cardListRepository));
        }

        async protected override Task<CreateCardResponse> DoExecuteAsync(CreateCardRequest command)
        {

            CreateCardArgs args = new()
            {
                CardId = Guid.NewGuid(),
                CardListId = command.CardListId,
                BackText = command.BackText,
                FrontText = command.FrontText,
                Tip = command.Tip,
                OwnerUserId = command.OwnerUserId
            };


            try
            {
                await this._cardListRepository.CreateCard(args);
                await this._unitOfWork.Commit();
            }
            catch
            {
                await this._unitOfWork.Rollback();
                throw;
            }

            return new CreateCardResponse()
            {
                NewId = args.CardId
            };
        }
    }
}
