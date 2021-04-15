using Aeon;
using Aeon.Domain;
using FluentValidation.Results;
using Ista.Domain.Cards;
using Ista.Domain.Users;
using System;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Commands.Cards.Update
{
    internal class UpdateCardHandler : Handler<UpdateCardRequest, UpdateCardResponse>
    {
        private readonly ICardListRepository _cardListRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly UpdateCardRequestValidator _validator;

       protected override Task<ValidationResult> DoValidateAsync(UpdateCardRequest command) => this._validator.ValidateAsync(command);

        public UpdateCardHandler(IUnitOfWork unitOfWork, UpdateCardRequestValidator validator, IUserRepository userRepository, ICardListRepository cardListRepository)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this._validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this._userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this._cardListRepository = cardListRepository ?? throw new ArgumentNullException(nameof(cardListRepository));
        }

        async protected override Task<UpdateCardResponse> DoExecuteAsync(UpdateCardRequest command)
        {

            UpdateCardArgs args = new()
            {
                CardId = command.CardId,
                BackText = command.BackText,
                FrontText = command.FrontText,
                Tip = command.Tip,
            };


            try
            {
                await this._cardListRepository.UpdateCard(args);
                await this._unitOfWork.Commit();
            }
            catch
            {
                await this._unitOfWork.Rollback();
                throw;
            }


            return new UpdateCardResponse();
        }
    }
}
