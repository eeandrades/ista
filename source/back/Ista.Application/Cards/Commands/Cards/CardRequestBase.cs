using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Commands.Cards
{
    public class CardRequestBase<TResponse>: Aeon.Domain.RequestBase<TResponse>
        where TResponse: Aeon.Domain.ResponseBase
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid OwnerUserId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid CardListId { get; set; }
        public string FrontText { get; set; }
        public string BackText { get; set; }
        public string Tip { get; set; }        
    }
}
