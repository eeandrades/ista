using System;

namespace Ista.Application.Cards.Commands.CardsList.Create
{
    public class CreateCardListResponse: Aeon.Domain.ResponseBase
    {
        public Guid NewId { get; set; }
    }
}
