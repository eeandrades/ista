using System;

namespace Ista.Application.Cards.Queries
{
    public class CardListBrief
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public int CardCount { get; init; }

        public DateTime CreationDate { get; init; }
    }
}
