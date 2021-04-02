using Aeon.Domain;
using System;

namespace Ista.Entities.Cards
{
    public class Card: Entity<Guid>
    {
        public string Tip { get; init; }
        public Face Front { get; init; }
        public Face Back { get; init; }
    }
}
