using Ista.Domain.Cards;
using Ista.Domain.Users;
using Ista.Repository.EntityFramework.Users.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ista.Repository.EntityFramework.Cards.Tables
{
    internal class CardListTable
    {
        public string Uid { get; set; }

        public string Name { get; set; }

        public Int16 Scope { get; set; }

        public ICollection<CardTable> Cards { get; set; } = new HashSet<CardTable>();

        public string UserOwnerId { get; set; }

        public UserTable Owner { get; set; }

        public bool IsNew => string.IsNullOrEmpty(this.Uid);

        public  CardList ToEntity()
        {
            return new CardList()
            {
                Id = Guid.Parse(this.Uid),
                Name = this.Name,
                Owner = this.Owner?.ToEntity()??User.Empty,
                Scope = (Scope)this.Scope,
                Cards = this.Cards
                .Select(c=>c.ToEntity())
                .ToArray()
            };
                
        }

        public static CardListTable FronEntity(CardList cardList)
        {
            return new CardListTable()
                .FillFromEntity(cardList);
        }

        public CardListTable FillFromEntity(CardList cardList)
        {
            this.Uid = Convert.ToString(cardList.Id);
            this.Name = cardList.Name;
            this.Scope = (Int16)cardList.Scope;
            this.UserOwnerId = Convert.ToString(cardList.User?.Id);
            return this;
        }
    }
}
