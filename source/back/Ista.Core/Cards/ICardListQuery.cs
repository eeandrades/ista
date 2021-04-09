using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ista.Domain.Cards
{
    public interface ICardListQuery
    {
        Task<IEnumerable<CardListBrief>> FindByUser(Guid userId);
    }
}
