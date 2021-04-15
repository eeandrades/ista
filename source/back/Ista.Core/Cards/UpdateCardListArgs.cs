using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Domain.Cards
{
    public class UpdateCardListArgs
    {
        public Guid CardListId { get; set; }
        public string Name { get; set; }
        public Scope Scope { get; set; }
    }
}
