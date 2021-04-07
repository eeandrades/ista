using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Queries
{
    public class CardList
    {
        public Guid Id { get; init; }

        public string Name { get; set; }

        public CardListScope Scope { get; init; }

        public IEnumerable<Card> Cards { get; init; }

        public User Owner { get; init; }

        public bool ReadOnly { get; init; }
    }
}
