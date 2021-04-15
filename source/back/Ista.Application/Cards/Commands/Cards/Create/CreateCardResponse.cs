using System;

namespace Ista.Application.Cards.Commands.Cards.Create
{
    public class CreateCardResponse: Aeon.Domain.ResponseBase
    {
        public Guid NewCardId { get; set; }
    }
}
