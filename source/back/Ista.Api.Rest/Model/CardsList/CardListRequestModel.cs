using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Api.Rest.Model.CardsList
{
    public class CardListRequestModel
    {
        public string Name { get; set; }
        public CardListScopeModel Scope { get; set; }
    }
}
