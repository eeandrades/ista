using Aeon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Domain.Cards
{
    public class CardListBrief: Entity<Guid>
    {
        public string Name { get; set; }

        public int CardCount { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
