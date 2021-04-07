using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ista.Domain.Cards;

namespace Ista.Application.Cards.Commands.SaveCard
{
    internal static class ConvertExtensions
    {
        public static void FillCardFromRequest(this Card card, SaveCardRequest saveCardRequest)
        {
            card.Tip = saveCardRequest.TipText;
            card.Back = new Face()
            {
                Text = saveCardRequest.BackText
            };
            card.Front = new Face()
            {
                Text = saveCardRequest.FrontText
            };
        }
    }
}

