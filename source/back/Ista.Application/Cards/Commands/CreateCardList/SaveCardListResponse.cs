using System;

namespace Ista.Application.Cards.Commands.SaveCardList
{
    public class SaveCardListResponse: Aeon.Domain.ResponseBase
    {
        public Guid CadListUid { get; set; }
    }
}
