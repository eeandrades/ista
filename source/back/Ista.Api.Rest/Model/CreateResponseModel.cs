using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ista.Api.Rest.Model
{
    public class CreateResponseModel: ResponseModel
    {
        public Guid NewId { get; set; }
    }
}
