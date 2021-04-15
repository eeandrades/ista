using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Domain.Cards
{
    public class CardListInfo
    {
        public Guid Id { get; init; }

        public Guid OwnerId { get; init; }

        public readonly static CardListInfo Empty = new CardListInfo();

        public bool IsEmpty => this == Empty;
    }
}
