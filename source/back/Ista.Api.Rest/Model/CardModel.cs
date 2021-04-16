using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Api.Rest.Model
{
    public class CardModel
    {
        public Guid Id { get; set; }
        
        public string Tip { get; set; }

        public string FrontText { get; set; }

        public string BackText { get; set; }
    }
}
