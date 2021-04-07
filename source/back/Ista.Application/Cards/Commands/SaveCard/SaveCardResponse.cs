using System;

namespace Ista.Application.Cards.Commands.SaveCard
{
    public class SaveCardResponse : Aeon.Domain.ResponseBase
    {
        public Guid CardId { get; init; }
    }
}
