using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Commands.CardsList
{
    public class CardListRequestBase<TResponse>: Aeon.Domain.RequestBase<TResponse>
        where TResponse: Aeon.Domain.ResponseBase
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid OwnerUserId { get; set; }
        public string Name { get; set; }
        public CardListScope Scope { get; set; }
    }
}
