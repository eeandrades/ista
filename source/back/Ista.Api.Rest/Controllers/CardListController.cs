using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ista.Commands.Cards.CreateCardList;
using MediatR;

namespace Ista.Api.Rest.Controllers
{
    [Route("api/lists")]
    public class CardListController : Controller
    {
        [HttpPost]
        public async Task<CreateCardListResponse> Add([FromServices] IMediator mediator, [FromBody] CreateCardListRequest request)
        {
            return await mediator.Send(request);
        }
    }
}
