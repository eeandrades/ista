
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Api.Rest.Model
{
    public class CardListModel
    {
        public Guid Id { get; init; }

        public string Name { get; set; }

        public CardListScopeModel Scope { get; init; }

        public IEnumerable<CardModel> Cards { get; init; }

        public UserModel Owner { get; init; }

        public bool ReadOnly { get; init; }
    }
}
