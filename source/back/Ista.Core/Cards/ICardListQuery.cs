using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Domain.Cards
{
    public interface ICardListQuery
    {
        IEnumerable<CardListBrief> FindByUser(Guid userId);
    }
}
