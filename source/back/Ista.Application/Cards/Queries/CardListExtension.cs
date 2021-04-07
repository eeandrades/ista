using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Application.Cards.Queries
{
    internal static class CardListExtension
    {
        public static CardList CreateFromEntity(this Domain.Cards.CardList entity)
        {
            return new CardList()
            {
                Id = entity.Id,
                Name = entity.Name,
                Owner = new User()
                {
                    Id = entity.Owner.Id,
                    Name = entity.Owner.Name
                },
                ReadOnly = entity.ReadOnly,
                Scope = (CardListScope)entity.Scope,
                Cards = entity.Cards.Select(c => new Card() {
                    Id = c.Id,
                    BackText = c.Back.Text,
                    FrontText = c.Front.Text,
                    Tip = c.Tip,
                })
            };
        }
    }
}
