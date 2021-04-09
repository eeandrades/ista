using Ista.Domain.Cards;
using System;

namespace Ista.Repository.EntityFramework.Cards.Tables
{
    internal class CardTable
    {
        public string Uid { get; set; }

        public string Tip { get; set; }

        public string TextFront { get; set; }

        public string TextBack { get; set; }

        public string IdCardList { get; set; }

        public CardListTable CardList { get; set; }

        internal Card ToEntity()
        {
            return new Card()
            {
                Id = Guid.Parse(Uid),
                Tip = this.Tip,
                Back = Face.FromText(this.TextBack),
                Front = Face.FromText(this.TextFront)
            };
        }
    }
}
