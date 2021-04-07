using Ista.Application.Cards.Commands.SaveCard;
using Ista.Application.Cards.Commands.SaveCardList;
using Ista.Application.Cards.Queries.GetCardListById;
using Ista.Application.Cards.Queries.GetCardsByUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ista.Api.Rest.Controllers
{
    [Route("api/lists")]
    public class CardListController : ControllerBase
    {
        [HttpPost]
        public async Task<SaveCardListResponse> AddCardList([FromServices] IMediator mediator, [FromBody] SaveCardListRequest request)
        {
            return await mediator.Send(request);
        }

        [HttpGet]
        [Route("{ListId}")]
        public async Task<GetCardListByIdResponse> GetCardListById([FromServices] IMediator mediator, [FromRoute] GetCardListByIdRequest request)
        {
            return await mediator.Send(request);
        }

        [HttpGet]
        public async Task<GetCardsByUserResponse> GetCardList([FromServices] IMediator mediator, [FromQuery] GetCardsByUserRequest request)
        {
            return await mediator.Send(request);
        }

        [HttpPost]
        [Route("{id}/Cards")]
        public async Task<SaveCardResponse> AddCard
            ([FromServices] IMediator mediator, [FromRoute] Guid id, [FromBody] SaveCardRequest request)
        {
            request.ListId = id;
            return await mediator.Send(request);
        }
    }
}
