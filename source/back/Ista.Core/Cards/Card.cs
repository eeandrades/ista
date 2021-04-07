using Aeon.Domain;
using System;

namespace Ista.Domain.Cards
{
    public class Card : Entity<Guid>
    {
        public string Tip { get; set; }
        public Face Front { get; set; }
        public Face Back { get; set; }


        public static readonly Card Empty = new Card()
        {
            Id = Guid.Empty,
        };

        public bool IsEmpty => this == Empty;
    }
}
