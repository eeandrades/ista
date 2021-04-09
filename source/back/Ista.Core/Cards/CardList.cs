using Aeon;
using Aeon.Domain;
using Ista.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ista.Domain.Cards
{
    public class CardList : Entity<Guid>
    {
        public string Name { get; set; }
        public Scope Scope { get; set; }
        public User Owner { get; set; }
        public User User { get; set; }
        public bool ReadOnly => Owner != User;

        public DateTime CreationDate { get; set; }
        private readonly List<Card> _cards = new List<Card>();
        public IEnumerable<Card> Cards
        {
            get => this._cards;
            init
            {
                _cards = _cards ?? throw new NullReferenceException();
                if (value != null)
                    this._cards.AddRange(value);
            }
        }

        public CardList AddCard(params Card[] card)
        {
            this._cards.AddRange(card);
            return this;
        }

        public Card FindCardById(Guid cardId)
        {
            if (cardId.IsEmpty())
                return Card.Empty;

            return this.Cards
                .Where(c => c.Id == cardId)
                .DefaultIfEmpty(Card.Empty)
                .First();
        }

        public static readonly CardList Empty = new CardList()
        {
            Id = Guid.Empty,
            Name = string.Empty
        };

        public bool IsEmpty => this == Empty;
    }
}
