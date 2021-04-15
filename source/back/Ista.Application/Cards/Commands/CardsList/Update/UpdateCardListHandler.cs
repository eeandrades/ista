using Aeon;
using Aeon.Domain;
using FluentValidation.Results;
using Ista.Domain.Cards;
using Ista.Domain.Users;
using System;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Commands.CardsList.Update
{

    internal class UpdateCardListHandler : Aeon.Domain.Handler<UpdateCardListRequest, UpdateCardListResponse>
    {

        private readonly ICardListRepository _cardListRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly UpdateCardListRequestValidator _validator;


        protected override Task<ValidationResult> DoValidateAsync(UpdateCardListRequest command) => this._validator.ValidateAsync(command);

        public UpdateCardListHandler(IUnitOfWork unitOfWork, UpdateCardListRequestValidator validator, IUserRepository userRepository, ICardListRepository cardListRepository)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this._validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this._userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this._cardListRepository = cardListRepository ?? throw new ArgumentNullException(nameof(cardListRepository));
        }

        async protected override Task<UpdateCardListResponse> DoExecuteAsync(UpdateCardListRequest request)
        {

            CreateCardListArgs cardListUpdateArgs = new()
            {
                Id = request.CardListId,
                Name = request.Name,
                Scope = (Scope)request.Scope
            };


            try
            {

                await this._cardListRepository.Update(cardListUpdateArgs);
                await this._unitOfWork.Commit();
            }
            catch
            {
                await this._unitOfWork.Rollback();
                throw;
            }

            return new UpdateCardListResponse()
            {
                NewCardListId = cardListUpdateArgs.Id
            };
        }
    }
}
