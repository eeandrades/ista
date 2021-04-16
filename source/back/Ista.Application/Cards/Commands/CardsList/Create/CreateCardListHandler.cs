using Aeon;
using Aeon.Domain;
using FluentValidation.Results;
using Ista.Domain.Cards;
using Ista.Domain.Users;
using System;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Commands.CardsList.Create
{

    internal class CreateCardListHandler : Aeon.Domain.Handler<CreateCardListRequest, CreateCardListResponse>
    {

        private readonly ICardListRepository _cardListRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly CreateCardListRequestValidator _validator;

        protected override Task<ValidationResult> DoValidateAsync(CreateCardListRequest command) => this._validator.ValidateAsync(command);

        public CreateCardListHandler(IUnitOfWork unitOfWork, CreateCardListRequestValidator validator, IUserRepository userRepository, ICardListRepository cardListRepository)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this._validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this._userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this._cardListRepository = cardListRepository ?? throw new ArgumentNullException(nameof(cardListRepository));
        }

        async protected override Task<CreateCardListResponse> DoExecuteAsync(CreateCardListRequest command)
        {

            CreateCardListArgs cardListCreateArgs = new()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                OwnerUserId = command.OwnerUserId,
                Scope = (Scope) command.Scope
            };             


            try
            {

                await this._cardListRepository.Create(cardListCreateArgs);
                await this._unitOfWork.Commit();
            }
            catch
            {
                await this._unitOfWork.Rollback();
                throw;
            }

            return new CreateCardListResponse()
            {
                NewId = cardListCreateArgs.Id
            };
        }
    }
}
