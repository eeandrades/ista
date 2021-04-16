using System;

namespace Ista.Api.Rest.Model
{ 
    public class CardListBriefModel
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public int CardCount { get; init; }

        public DateTime CreationDate { get; init; }
    }
}
