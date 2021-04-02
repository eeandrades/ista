using Ista.Entities.Cards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ista.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CardList card1 = new CardList()
            {
                Cards = null
            };

            
            Console.WriteLine($"Quantidade: {card1.Cards.Count()}");
        }
    }
}
