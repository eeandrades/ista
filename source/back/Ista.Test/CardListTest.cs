using Ista.Domain.Cards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ista.Test
{
    [TestClass]
    public class CardListTest
    {
        [TestMethod]
        public void FindCardById_NotFound()
        {
            Card card = GetCard(Guid.NewGuid(), Guid.NewGuid());

            Assert.IsTrue(card.IsEmpty);
        }

        [TestMethod]
        public void FindCardById_Found()
        {
            var id = Guid.NewGuid();
            Card card = GetCard(id, id);

            Assert.IsTrue(card.Id == id);
        }

        private static Card GetCard(Guid idCard, Guid idCardFind)
        {
            CardList cardList = new CardList();

            cardList.AddCard(
                new Card()
                {
                    Id = idCard
                });


            var card = cardList.FindCardById(idCardFind);
            return card;
        }
    }
}
