using Aeon.Domain;
using FluentValidation.Results;
using Ista.Domain.Cards;
using Ista.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Domain.Cards
{
    public class CardListValidator
    {
        private readonly ICardListQuery cardListQuery;

        
        public CardListValidator(ICardListQuery cardListQuery)
        {
            this.cardListQuery = cardListQuery ?? throw new ArgumentNullException(nameof(cardListQuery));
        }


        public async Task ListExistsForUser(Guid ownerId, Guid cardListId, ValidationResult result)
        {
            var info = await this.cardListQuery.FindInfo(cardListId);

            if (info.IsEmpty)
            {
                result.AddError(($"Lista {cardListId} não encontrada."));
            }

            if (info.OwnerId != ownerId)
            {
                result.AddError(($"A lista informada não pertence ao usuário."));
            }
        }

        public async Task NomeJaExiste(ExistsCardListtNameArgs args, ValidationResult result)
        {

            if (await this.cardListQuery.ExistsCardListName(args))
            {
                result.AddError(($"A lista {args.Name} já existe."));
            }
        }
    }
}
