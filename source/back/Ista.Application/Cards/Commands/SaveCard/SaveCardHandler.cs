﻿using FluentValidation.Results;
using Ista.Domain.Cards;
using Aeon.Domain;
using System;

namespace Ista.Application.Cards.Commands.SaveCard
{
    internal class SaveCardHandler : Aeon.Domain.CommandHandler<SaveCardRequest, SaveCardResponse>
    {
        private readonly ICardListRepository _cardListRepository;

        public SaveCardHandler(ICardListRepository cardListRepository)
        {
            this._cardListRepository = cardListRepository;
        }


        protected override SaveCardResponse DoExecute(SaveCardRequest command)
        {
            var cardList = this._cardListRepository.FindById(command.ListId);

            bool Validate(out ValidationResult validationResult)
            {
                validationResult = new ValidationResult();
                if (cardList.IsEmpty)
                    validationResult.AddError($"Lista {command.ListId} não encontrada.");
                return validationResult.IsValid;
            }            

            if (!Validate(out var validationResult))
            {
                validationResult.CreateResponse<SaveCardResponse>();
            }


            var card = cardList.FindCardById(command.ListId);

            if (card.IsEmpty)
            {
                card = new Card()
                {
                    Id = command.Id
                };
                cardList.AddCard(card);
            }

            card.FillCardFromRequest(command);

            this._cardListRepository.Save(cardList);

            return new SaveCardResponse()
            {
                CardId = command.Id
            };
        }
    }
}