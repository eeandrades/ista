using System;

namespace Ista.Commands.Cards.CreateCardList
{
    public class CreateCardListResponse: Aeon.Domain.ResponseBase
    {
        public Guid CadListUid { get; set; }
    }
}
