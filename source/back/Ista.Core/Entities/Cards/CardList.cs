using Aeon.Domain;
using System;
using System.Collections.Generic;

namespace Ista.Entities.Cards
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
    }
}
