using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Domain.Cards
{
    public class ExistsCardListtNameArgs
    {
        public Guid CardListId { get;  init; }

        public Guid OwnerUserId { get; init; }

        public string Name { get; init; }
    }
}
