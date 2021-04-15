using System;

namespace Ista.Application.Cards.Commands.CardsList.Update
{
    public class UpdateCardListResponse : Aeon.Domain.ResponseBase
    {
        public Guid NewCardListId { get; set; }
    }
}
