using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Domain.Cards
{
    public class UpdateCardArgs
    {
        public Guid CardId { get; set; }
        public string FrontText { get; set; }
        public string BackText { get; set; }
        public string Tip { get; set; }
    }
}
